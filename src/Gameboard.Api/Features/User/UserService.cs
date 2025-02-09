// Copyright 2021 Carnegie Mellon University. All Rights Reserved.
// Released under a MIT (SEI)-style license. See LICENSE.md in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gameboard.Api.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Gameboard.Api.Services;

public class UserService
{
    IUserStore Store { get; }
    IMapper Mapper { get; }

    private readonly IMemoryCache _localcache;
    private readonly INameService _namesvc;
    private readonly Defaults _defaultOptions;

    public UserService(
        IUserStore store,
        IMapper mapper,
        IMemoryCache cache,
        INameService namesvc,
        Defaults defaultOptions
    )
    {
        Store = store;
        Mapper = mapper;
        _localcache = cache;
        _namesvc = namesvc;
        _defaultOptions = defaultOptions;
    }

    /// <summary>
    /// If user exists update fields
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<User> Create(NewUser model)
    {
        var entity = await Store.Retrieve(model.Id);

        if (entity is Data.User && entity.Id.HasValue())
        {
            // entity.Name = model.Name;
            // // entity.Email = model.Email;
            // // entity.Username = model.Username;
            // await Store.Update(entity);
        }
        else
        {
            entity = Mapper.Map<Data.User>(model);

            bool found = false;
            int i = 0;
            do
            {
                entity.ApprovedName = _namesvc.GetRandomName();
                entity.Name = entity.ApprovedName;

                // check uniqueness
                found = await Store.DbSet.AnyAsync(p =>
                    p.Id != entity.Id &&
                    p.Name == entity.Name
                );
            } while (found && i++ < 20);

            entity.Sponsor = _defaultOptions.DefaultSponsor;

            await Store.Create(entity);
        }

        _localcache.Remove(entity.Id);

        return Mapper.Map<User>(entity);
    }

    public async Task<User> Retrieve(string id)
    {
        return Mapper.Map<User>(await Store.Retrieve(id));
    }

    public async Task Update(ChangedUser model, bool sudo, bool admin = false)
    {
        var entity = await Store.Retrieve(model.Id);
        bool differentName = entity.Name != model.Name;

        if (!sudo)
        {
            Mapper.Map(
                Mapper.Map<SelfChangedUser>(model),
                entity
            );

            entity.NameStatus = entity.Name != entity.ApprovedName
                ? "pending"
                : ""
            ;
        }
        else
        {
            if (!admin && model.Role != entity.Role)
                throw new ActionForbidden();

            Mapper.Map(model, entity);
        }

        if (differentName)
        {
            // check uniqueness
            bool found = await Store.DbSet.AnyAsync(p =>
                p.Id != entity.Id &&
                p.Name == entity.Name
            );

            if (found)
                entity.NameStatus = AppConstants.NameStatusNotUnique;
        }

        await Store.Update(entity);

        _localcache.Remove(entity.Id);

    }

    public async Task Delete(string id)
    {
        await Store.Delete(id);

        _localcache.Remove(id);

    }

    public async Task<User[]> List(UserSearch model)
    {
        var q = Store.List(model.Term);

        if (model.Term.HasValue())
        {
            model.Term = model.Term.ToLower();
            q = q.Where(u =>
                u.Id.StartsWith(model.Term) ||
                u.Name.ToLower().Contains(model.Term) ||
                u.ApprovedName.ToLower().Contains(model.Term)
            );
        }

        if (model.WantsRoles)
            q = q.Where(u => ((int)u.Role) > 0);

        if (model.WantsPending)
            q = q.Where(u => u.NameStatus.Equals(AppConstants.NameStatusPending));

        if (model.WantsDisallowed)
            q = q.Where(u => !string.IsNullOrEmpty(u.NameStatus) && !u.NameStatus.Equals(AppConstants.NameStatusPending));

        q = q.OrderBy(p => p.ApprovedName);

        q = q.Skip(model.Skip);

        if (model.Take > 0)
            q = q.Take(model.Take);

        return await Mapper.ProjectTo<User>(q).ToArrayAsync();
    }

    public async Task<UserSummary[]> ListSupport(SearchFilter model)
    {
        var q = Store.List(model.Term);

        // Might want to also include observers if they can be assigned. Or just make possible assignees "Support" roles
        q = q.Where(u => u.Role.HasFlag(UserRole.Support));

        if (model.Term.HasValue())
        {
            model.Term = model.Term.ToLower();
            q = q.Where(u =>
                u.Id.StartsWith(model.Term) ||
                u.Name.ToLower().Contains(model.Term) ||
                u.ApprovedName.ToLower().Contains(model.Term)
            );
        }

        return await Mapper.ProjectTo<UserSummary>(q).ToArrayAsync();
    }

    internal string ResolveRandomName(IUserStore store, INameService nameSvc, User entity)
    {
        var randomName = nameSvc.GetRandomName();
        var existing = store.DbSet.AnyAsync(p => p.Id != entity.Id && p.Name == entity.Name);

        if (existing != null)
        {
            return $"{randomName}_${DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        }

        return randomName;
    }
}
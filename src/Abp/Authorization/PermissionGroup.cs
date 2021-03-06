﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Localization;

namespace Abp.Authorization
{
    /// <summary>
    /// Represents a permission group.
    /// A permission group can have subgroups and permissions.
    /// </summary>
    public sealed class PermissionGroup
    {
        /// <summary>
        /// Parent of this permission group if one exists.
        /// </summary>
        public PermissionGroup Parent { get; private set; }

        /// <summary>
        /// Unique name of the permission group.
        /// This is the key name to identify this group.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Display name of the permission group.
        /// </summary>
        public ILocalizableString DisplayName { get; private set; }

        /// <summary>
        /// List of child permission groups.
        /// </summary>
        public IReadOnlyList<PermissionGroup> Children
        {
            get { return _children.ToImmutableList(); }
        }
        private readonly List<PermissionGroup> _children;

        /// <summary>
        /// List of permissions in this group.
        /// </summary>
        public IReadOnlyList<Permission> Permissions
        {
            get { return _permissions.ToImmutableList(); }
        }
        private readonly List<Permission> _permissions;

        /// <summary>
        /// Creates a new <see cref="PermissionGroup"/> object.
        /// </summary>
        internal PermissionGroup(string name, ILocalizableString displayName)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName");
            }

            Name = name;
            DisplayName = displayName;
            _children = new List<PermissionGroup>();
            _permissions = new List<Permission>();
        }

        /// <summary>
        /// Creates a new permission under this group.
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="isGrantedByDefault">Is this permission granted by default. Default value: false.</param>
        /// <param name="description">A brief description for this permission</param>
        /// <returns>New created permission</returns>
        public Permission CreatePermission(string name, ILocalizableString displayName, bool isGrantedByDefault = false, ILocalizableString description = null)
        {
            var permission = new Permission(name, displayName, isGrantedByDefault, description);
            _permissions.Add(permission);
            return permission;
        }

        /// <summary>
        /// Creates a new child permission group under this group.
        /// </summary>
        /// <param name="name">Unique name of the group</param>
        /// <param name="displayName">Display name of the group</param>
        /// <returns>Newly created child permission group object</returns>
        public PermissionGroup CreateChildGroup(string name, ILocalizableString displayName)
        {
            var childGroup = new PermissionGroup(name, displayName) { Parent = this };
            _children.Add(childGroup);
            return childGroup;
        }
    }
}
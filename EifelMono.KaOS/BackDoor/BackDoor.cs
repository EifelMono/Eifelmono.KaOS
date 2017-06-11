﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EifelMono.KaOS
{
    public static class BackDoor
    {
        #region Definition

        internal class Item
        {
            private Type _ClassType;

            internal Type ClassType
            {
                get { return _ClassType; }
                set
                {
                    _ClassType = value;
                    ClassTypeInfo = value.GetTypeInfo();
                }
            }

            internal TypeInfo ClassTypeInfo { get; set; }

            private Type _InterfaceType;

            internal Type InterfaceType
            {
                get { return _InterfaceType; }
                set
                {
                    _InterfaceType = value;
                    InterfaceTypeInfo = value.GetTypeInfo();
                }
            }

            internal TypeInfo InterfaceTypeInfo { get; set; }

            internal object Object { get; set; }
        }

        internal static List<Item> _Items = null;

        internal static void FindAssemblyItems(Assembly assembly)
        {
            if (assembly == null)
                return;
            object[] attributes = assembly.GetCustomAttributes(typeof(BackDoorAttribute)).ToArray<Attribute>();
            if (attributes.Length != 0)
                foreach (BackDoorAttribute attribute in attributes)
                    _Items.Add(new Item() { ClassType = attribute.ClassType });  
        }
            
        internal static List<Item> Items
        {
            get
            {
                if (_Items== null)
                {
                    _Items = new List<Item>();
                    FindAssemblyItems(Assembly.GetEntryAssembly());
                    foreach (var assemblyName in Assembly.GetEntryAssembly().GetReferencedAssemblies())
                        FindAssemblyItems(Assembly.Load(assemblyName));
                }
                return _Items;
            }
        }

        #endregion

        #region Create

        internal enum Mode
        {
            Instance,
            New,
        }

        internal static T Get<T>(Mode mode) where T : class
        {
            Type interfaceType = typeof(T);
            TypeInfo interfaceTypeInfo = interfaceType.GetTypeInfo();
            Item item = Items.FirstOrDefault(i => i.InterfaceType == interfaceType);
            if (item == null)
            {
                // from interface to class !
                item = Items.FirstOrDefault(a => interfaceTypeInfo.IsAssignableFrom(a.ClassTypeInfo));
                if (item != null)
                    item.InterfaceType = interfaceType;
            }
            if (item != null)
            {
                if (mode == Mode.New)
                    return (T)Activator.CreateInstance(item.ClassType);
                else
                {
                    if (item.Object == null)
                        item.Object = (T)Activator.CreateInstance(item.ClassType);
                    return (T)item.Object;
                }
            }

            return null;

        }

        public static T New<T>() where T : class
        {
            return Get<T>(BackDoor.Mode.New);
        }

        public static T Instance<T>() where T : class
        {
            return Get<T>(BackDoor.Mode.Instance);
        }
        #endregion
    }
}

// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections;
using System.Configuration;
using System.Linq;

namespace QueryFramework.Relational.Configuration
{

   [ConfigurationCollection(typeof(ProviderElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
   internal class ProviderCollection : ConfigurationElementCollection
   {

      #region [ Static Fields ]


      private static ConfigurationPropertyCollection properties;


      #endregion


      #region [ Constructors ]


      static ProviderCollection()
      {
         properties = new ConfigurationPropertyCollection();
      }


      protected ProviderCollection()
         : base(new CaseInsensitiveComparer())
      {
      }


      #endregion


      #region [ Properties ]


      public ProviderElement this[int index]
      {
         get { return (ProviderElement)BaseGet(index); }
         set { if (BaseGet(index) != null) BaseRemoveAt(index); BaseAdd(index, value); }
      }


      public new ProviderElement this[string name]
      {
         get { return (ProviderElement)BaseGet(name); }
      }


      public string[] AllKeys
         => BaseGetAllKeys().Cast<string>().ToArray();


      #endregion


      #region [ Override Implementation of ConfigurationElementCollection ]


      protected override ConfigurationElement CreateNewElement()
      {
         return new ProviderElement();
      }


      protected override object GetElementKey(ConfigurationElement element)
      {
         return ((ProviderElement)element).Name;
      }


      protected override ConfigurationPropertyCollection Properties
      {
         get { return properties; }
      }


      #endregion

   }

}

// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace QueryFramework.Storage
{

   public class ParameterNameGenerator
   {

      #region [ Fields ]


      private Dictionary<string, int> _parameterNameCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
      private int _count;


      #endregion


      #region [ Methods ]


      public virtual string GenerateNext(string originalName)
      {
         if (originalName == null || originalName == "" || originalName == "p")
         {
            return "p" + _count++;
         }

         if (_parameterNameCounter.ContainsKey(originalName))
         {
            return originalName + (++_parameterNameCounter[originalName]);
         }
         else
         {
            _parameterNameCounter.Add(originalName, 0);
            return originalName;
         }
      }


      #endregion

   }

}

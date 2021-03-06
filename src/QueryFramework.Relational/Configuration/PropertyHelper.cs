// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Configuration;

namespace QueryFramework.Relational.Configuration
{

   internal static class PropertyHelper
   {

      internal static StringConverter
         StringConverter = new StringConverter();
      internal static CommaDelimitedStringCollectionConverter
         CommaDelimitedStringCollectionConverter = new CommaDelimitedStringCollectionConverter();
      internal static InfiniteIntConverter
         InfiniteIntConverter = new InfiniteIntConverter();
      internal static InfiniteTimeSpanConverter
         InfiniteTimeSpanConverter = new InfiniteTimeSpanConverter();
      internal static TimeSpanMinutesConverter
         TimeSpanMinutesConverter = new TimeSpanMinutesConverter();
      internal static TimeSpanMinutesOrInfiniteConverter
         TimeSpanMinutesOrInfiniteConverter = new TimeSpanMinutesOrInfiniteConverter();
      internal static TimeSpanSecondsConverter
         TimeSpanSecondsConverter = new TimeSpanSecondsConverter();
      internal static TimeSpanSecondsOrInfiniteConverter
         TimeSpanSecondsOrInfiniteConverter = new TimeSpanSecondsOrInfiniteConverter();
      internal static WhiteSpaceTrimStringConverter
         WhiteSpaceTrimStringConverter = new WhiteSpaceTrimStringConverter();


      internal static DefaultValidator
         DefaultValidator = new DefaultValidator();
      internal static StringValidator
         NonEmptyStringValidator = new StringValidator(1);
      internal static PositiveTimeSpanValidator
         PositiveTimeSpanValidator = new PositiveTimeSpanValidator();
      internal static IntegerValidator
         IntFromZeroToMaxValidator = new IntegerValidator(0, Int32.MaxValue);
      internal static IntegerValidator
         IntFromOneToMax_1Validator = new IntegerValidator(1, Int32.MaxValue - 1);

   }

}


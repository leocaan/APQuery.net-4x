// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using System;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlProjectableExpr : SqlExpr
   {

      #region [ Constructors ]


      public SqlProjectableExpr(SqlOperableExpr operand)
      {
         Operand = operand;
      }


      #endregion


      #region [ Properties ]


      public virtual SqlOperableExpr Operand { get; }


      public virtual string ResultName
         => (Operand as SqlColumnExpr)?.Name;


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
      {
         Operand.Accept(visitor);


         return this;
      }


      #endregion


      #region [ Override Implementation of Implicit Operator ]


      public static implicit operator SqlProjectableExpr(SqlOperableExpr expr)
         => SqlExpr.Project(expr);


      public static implicit operator SqlProjectableExpr(bool value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(short value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(int value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(long value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(ushort value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(uint value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(ulong value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(byte value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(sbyte value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(char value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(string value)
         => value == "*"
            ? SqlExpr.Star
            : SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(byte[] value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(decimal value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(double value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(float value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(Guid value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(DateTime value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(DateTimeOffset value)
         => SqlExpr.Project(value);


      public static implicit operator SqlProjectableExpr(TimeSpan value)
         => SqlExpr.Project(value);


      #endregion

   }

}

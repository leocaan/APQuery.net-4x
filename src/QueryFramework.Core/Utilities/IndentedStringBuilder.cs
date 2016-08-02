using System;
using System.IO;
using System.Text;

namespace QueryFramework.Utilities
{

	public class IndentedStringBuilder
	{

		#region [ Fields ]


		private const byte IndentSize = 4;

		private byte _indent;
		private bool _indentPending = true;

		private readonly StringBuilder _stringBuilder = new StringBuilder();


		#endregion


		#region [ Constructors ]


		public IndentedStringBuilder()
		{
		}


		public IndentedStringBuilder(IndentedStringBuilder from)
		{
			Check.NotNull(from, nameof(from));

			_indent = from._indent;
		}


		#endregion


		#region [ Methods ]


		public virtual IndentedStringBuilder Append(object o)
		{
			Check.NotNull(o, nameof(o));

			DoIndent();

			_stringBuilder.Append(o);

			return this;
		}


		public virtual IndentedStringBuilder AppendLine()
		{
			AppendLine(string.Empty);

			return this;
		}


		public virtual IndentedStringBuilder AppendLine(object o)
		{
			Check.NotNull(o, nameof(o));

			var value = o.ToString();

			if (value != string.Empty)
			{
				DoIndent();
			}

			_stringBuilder.AppendLine(value);

			_indentPending = true;

			return this;
		}


		public virtual IndentedStringBuilder AppendLines(object o)
		{
			Check.NotNull(o, nameof(o));

			using (var reader = new StringReader(o.ToString()))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					AppendLine(line);
				}
			}

			return this;
		}


		public virtual IndentedStringBuilder IncrementIndent()
		{
			_indent++;
			return this;
		}


		public virtual IndentedStringBuilder DecrementIndent()
		{
			if (_indent > 0)
			{
				_indent--;
			}
			return this;
		}


		public virtual IDisposable Indent()
			=> new Indenter(this);


		#endregion


		#region [ Private Methods ]


		private void DoIndent()
		{
			if (_indentPending && _indent > 0)
			{
				_stringBuilder.Append(new string(' ', _indent * IndentSize));
			}

			_indentPending = false;
		}


		#endregion


		#region [ Override Implementation of Object ]


		public override string ToString()
			=> _stringBuilder.ToString();


		#endregion


		#region [ Helper Class ]


		private sealed class Indenter : IDisposable
		{

			private readonly IndentedStringBuilder _stringBuilder;


			public Indenter(IndentedStringBuilder stringBuilder)
			{
				_stringBuilder = stringBuilder;

				_stringBuilder.IncrementIndent();
			}


			public void Dispose()
			{
				_stringBuilder.DecrementIndent();
			}

		}


		#endregion

	}

}

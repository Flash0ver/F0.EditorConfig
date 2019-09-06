using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace F0.EditorConfig.DotNet.CSharp
{
	public class CodeStyles
	{
	}

	internal class ThisQualifiers
	{
		public ThisQualifiers()
		{
			// dotnet_style_qualification_for_field
			capacity = 0;

			// dotnet_style_qualification_for_property
			ID = 0;

			// dotnet_style_qualification_for_method
			Display();

			// dotnet_style_qualification_for_event
			Elapsed += Handler;
		}

		private readonly int capacity;

		public int ID { get; private set; }

		private void Display()
		{
			throw new NotImplementedException();
		}

		public event ElapsedEventHandler Elapsed;

		private void Handler(object sender, ElapsedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}

	internal class LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences
	{
		// dotnet_style_predefined_type_for_locals_parameters_members
		private int _member;

		public LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences()
		{
			// dotnet_style_predefined_type_for_member_access
			int local = Int32.MaxValue;

			Console.WriteLine(local);
		}

		private void Method(int value)
		{
			_member = value;
		}
	}

	internal class ModifierPreferences
	{
		// dotnet_style_require_accessibility_modifiers
		private const string thisFieldIsConst = "constant";

		// csharp_preferred_modifier_order
		private static readonly int _daysInYear = 365;

		// dotnet_style_readonly_field
		private readonly int _daysInWeek = 7;

	}

	internal class ParenthesesPreferences
	{
		public void Method(int a, int b, int c)
		{
			// dotnet_style_parentheses_in_arithmetic_binary_operators
			int v = a + (b * c);
		}

		public void Method(bool a, bool b, bool c)
		{
			// dotnet_style_parentheses_in_other_binary_operators
			bool v = a || (b && c);
		}

		public void Method(dynamic a)
		{
			// dotnet_style_parentheses_in_other_operators
			dynamic v = a.b.Length;
		}

		public void Method(int a, int b, int c, int d)
		{
			// dotnet_style_parentheses_in_relational_binary_operators
			bool v = (a < b) == (c > d);
		}
	}

	internal class ExpressionLevelPreferences
	{
		public ExpressionLevelPreferences()
		{
			// dotnet_style_object_initializer
			var c = new Customer() { Age = 21 };

			// dotnet_style_collection_initializer
			var list = new List<int> { 1, 2, 3 };

			// dotnet_style_explicit_tuple_names
			(string name, int age) customer = GetCustomer();
			string name = customer.name;

			// dotnet_style_prefer_inferred_tuple_names
			(int age, string name) tuple = (age, name);

			// dotnet_style_prefer_inferred_anonymous_type_member_names
			var anon = new { age, name };

			Console.WriteLine(tuple);
		}

		// dotnet_style_prefer_auto_properties
		private int Age { get; }

		public string Method(object value, bool expr)
		{
			// dotnet_style_prefer_is_null_check_over_reference_equality_method
			if (value is null)
			{
				return null;
			}

			// dotnet_style_prefer_conditional_expression_over_assignment
			string s = expr ? "hello" : "world";

			// dotnet_style_prefer_conditional_expression_over_return
			return expr ? "hello" : "world";
		}

		private class Customer
		{
			public Customer()
			{
			}

			public int Age { get; set; }
		}

		private (string name, int age) GetCustomer()
		{
			throw new NotImplementedException();
		}

		private readonly int age;
	}

	internal class NullCheckingPreferences
	{
		public NullCheckingPreferences(object x, object y)
		{
			// dotnet_style_coalesce_expression = true
			object v = x ?? y;
		}

		public NullCheckingPreferences(object o)
		{
			// dotnet_style_null_propagation = true
			string v = o?.ToString();
		}
	}

	internal class ImplicitAndExplicitTypes
	{
		public ImplicitAndExplicitTypes()
		{
			// csharp_style_var_for_built_in_types
			int x = 5;

			// csharp_style_var_when_type_is_apparent
			var obj = new Customer();

			// csharp_style_var_elsewhere
			bool f = Init();

			Console.WriteLine(x);
		}

		private class Customer
		{
			public Customer()
			{
			}
		}

		private bool Init()
		{
			throw new NotImplementedException();
		}
	}

	internal class ExpressionBodiedMembers<T>
	{
		// csharp_style_expression_bodied_methods
		public int GetAge() { return Age; }

		private class Customer
		{
			// csharp_style_expression_bodied_constructors
			public Customer(int age) { Age = age; }

			public int Age { get; }
		}

		public class ComplexNumber
		{
			public double Real { get; }
			public double Imaginary { get; }

			public ComplexNumber(double real, double imaginary)
			{
				Real = real;
				Imaginary = imaginary;
			}

			// csharp_style_expression_bodied_operators
			public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
			{ return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary); }
		}

		// csharp_style_expression_bodied_properties
		public int Age => _age + 0;

		// csharp_style_expression_bodied_indexers
		public T this[int i] => _values[i];

		private class Person
		{
			// csharp_style_expression_bodied_accessors
			public int Age { get => _age; set => _age = value - 0; }

			private int _age;
		}

		private readonly int _age;
		private readonly T[] _values;
	}

	internal class PatternMatching
	{
		public PatternMatching(object o)
		{
			// csharp_style_pattern_matching_over_is_with_cast_check
			if (o is int i)
			{ }

			// csharp_style_pattern_matching_over_as_with_null_check
			if (o is string s)
			{ }
		}
	}

	internal class InlinedVariableDeclarations
	{
		public InlinedVariableDeclarations(string value)
		{
			// csharp_style_inlined_variable_declaration
			if (Int32.TryParse(value, out int i))
			{ }
		}
	}

	internal class ExpressionLevelPreferences<T>
	{
		// csharp_prefer_simple_default_expression
		private void DoWork(CancellationToken cancellationToken = default) { }
	}

	internal class NullCheckingPreferences<T>
	{
		public NullCheckingPreferences(string s, Action<object> func, object args)
		{
			// csharp_style_throw_expression
			this.s = s ?? throw new ArgumentNullException(nameof(s));

			// csharp_style_conditional_delegate_call
			func?.Invoke(args);
		}

		private readonly string s;
	}

	internal class CodeBlockPreferences
	{
		public CodeBlockPreferences(bool test)
		{
			// csharp_prefer_braces
			if (test)
			{ Display(); }
		}

		private void Display()
		{
			throw new NotImplementedException();
		}
	}

	internal class MiscellaneousPreferences
	{
		public MiscellaneousPreferences()
		{
			// csharp_style_deconstructed_variable_declaration
			(string name, int age) = GetPersonTuple();
			Console.WriteLine($"{name} {age}");

			(int x, int y) = GetPointTuple();
			Console.WriteLine($"{x} {y}");
		}

		private static (string name, int age) GetPersonTuple()
		{
			return ("Name", 42);
		}

		private static (int x, int y) GetPointTuple()
		{
			return (1, 2);
		}

		public int Fibonacci(int value)
		{
			return fibonacci(value);

			// csharp_style_pattern_local_over_anonymous_function
			int fibonacci(int n)
			{
				return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
			}
		}
	}
}

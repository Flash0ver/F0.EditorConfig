using System.Diagnostics.CodeAnalysis;

namespace F0.EditorConfig.DotNet.CSharp;

public class UnnecessaryCode
{
}

[SuppressMessage("Style", "IDE0022:Use block body for methods", Justification = "<Pending>")]
internal class C1
{
	private int UsedMethod() => 0;

	public int PublicMethod() => UsedMethod();
}

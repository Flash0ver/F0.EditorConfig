namespace F0.EditorConfig.DotNet.CSharp;

public class UnnecessaryCode
{
}

// dotnet_remove_unnecessary_suppression_exclusions
internal class C1
{
	private int UsedMethod() => 0;

	public int PublicMethod() => UsedMethod();
}

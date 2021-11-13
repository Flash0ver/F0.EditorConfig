Public Class CodeStyles
End Class

Public Class ModifierPreferences

	' visual_basic_preferred_modifier_order
	Private Shared ReadOnly daysInYear As Integer = 365

	Public Function Func() As Integer
		Return daysInYear
	End Function

End Class

Public Class PatternMatchingPreferences

	' visual_basic_style_prefer_isnot_expression
	Public Function Func(o As Object, C As Object) As Boolean
		Dim y = o IsNot C

		Return y
	End Function

	' visual_basic_style_prefer_simplified_object_creation
	Public Function Create() As Student
		Dim x As New Student()

		Return x
	End Function

	Public Class Student
	End Class

End Class

Public Class UnnecessaryCode

	Public Sub Procedure()
		' visual_basic_style_unused_value_expression_statement_preference
		' visual_basic_style_unused_value_assignment_preference
		Dim unused = Computation()
	End Sub

	Private Function Computation() As Integer
		Return 240
	End Function

End Class

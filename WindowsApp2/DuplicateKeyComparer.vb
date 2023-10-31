Public Class DuplicateKeyComparer : Implements IComparer(Of Integer)

    Public Function Compare(x As Integer, y As Integer) As Integer Implements IComparer(Of Integer).Compare

        Dim result As Integer = x.CompareTo(y)

        If result = 0 Then
            Return 1
        Else
            Return result
        End If
    End Function
End Class

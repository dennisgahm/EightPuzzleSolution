Public Class EightPuzzleOrganizer
    Public list As List(Of EightPuzzle) = New List(Of EightPuzzle)
    Public Sub New()

    End Sub

    Public Sub Add(ByVal puzzle As EightPuzzle)
        If list.Count > 0 Then
            Dim findI As Integer = FindIndex(puzzle, 0, list.Count - 1)
            list.Insert(findI, puzzle)
        Else
            list.Add(puzzle)
        End If
    End Sub

    Public Function FindIndex(puzzle As EightPuzzle, startI As Integer, endI As Integer) As Integer

        If endI < startI Then
            Return startI
        End If

        Dim halfI As Integer = startI + ((endI - startI) / 2) 'note: test this
        Dim compareNum As Integer = Compare(puzzle, list(halfI))

        If compareNum = 0 Then
            Return halfI
        ElseIf compareNum < 0 Then
            If startI = halfI Then
                Return startI
            End If
            Return FindIndex(puzzle, startI, halfI)
        Else
            Return FindIndex(puzzle, halfI + 1, endI)
        End If

        Return -1

    End Function

    Public Function Compare(puzzle1 As EightPuzzle, puzzle2 As EightPuzzle) As Integer
        For i As Integer = 0 To 8
            Dim num1 As Integer = puzzle1.boardArray(i)
            Dim num2 As Integer = puzzle2.boardArray(i)
            If num1 = num2 Then
                Continue For
            ElseIf num1 < num2 Then
                Return -1
            Else
                Return 1
            End If
        Next

        Return 0
    End Function


End Class

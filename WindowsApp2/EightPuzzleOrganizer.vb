Public Class EightPuzzleOrganizer

    'Check if last index and boudnary cases are working for inserting 8puzzle into organizer


    Public list As List(Of EightPuzzle) = New List(Of EightPuzzle)
    Public Sub New()

    End Sub

    Public Function Contains(puzzle As EightPuzzle) As Boolean
        If list.Count = 0 Then
            Return False

        End If
        Dim index As Integer = BinarySearch(puzzle)

        Return Not (index = -1)
    End Function

    Public Sub Add(ByVal puzzle As EightPuzzle)
        If list.Count > 0 Then
            Dim findI As Integer = BinarySearchOfWhereToInsert(puzzle)
            list.Insert(findI, puzzle)
        Else
            list.Add(puzzle)
        End If
    End Sub

    'Public Function FindIndex(puzzle As EightPuzzle, startI As Integer, endI As Integer) As Integer

    '    If endI < startI Then
    '        Return startI
    '    End If

    '    Dim halfI As Integer = startI + ((endI - startI) / 2) 'note: test this
    '    Dim compareNum As Integer = Compare(puzzle, list(halfI))

    '    If compareNum = 0 Then
    '        Return halfI
    '    ElseIf compareNum < 0 Then
    '        If startI = halfI Then
    '            Return startI
    '        End If
    '        Return FindIndex(puzzle, startI, halfI)
    '    Else
    '        Return FindIndex(puzzle, halfI + 1, endI)
    '    End If

    '    Return -1

    'End Function

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

    Function BinarySearch(ByVal puzzle As EightPuzzle) As Integer
        Dim left As Integer = 0
        Dim right As Integer = list.Count - 1

        While left <= right
            Dim mid As Integer = left + (right - left) \ 2

            Dim compareNum As Integer = Compare(puzzle, list(mid))

            If compareNum = 0 Then
                Return mid ' Target found, return the index
            ElseIf compareNum >= 0 Then
                left = mid + 1 ' Search the right half
            Else
                right = mid - 1 ' Search the left half
            End If
        End While

        Return -1 ' Target not found
    End Function

    Function BinarySearchOfWhereToInsert(ByVal puzzle As EightPuzzle) As Integer
        Dim left As Integer = 0
        Dim right As Integer = list.Count - 1

        While left <= right
            Dim mid As Integer = left + (right - left) \ 2

            Dim compareNum As Integer = Compare(puzzle, list(mid))

            If compareNum = 0 Then
                Return mid ' Target found, return the index
            ElseIf compareNum >= 0 Then
                left = mid + 1 ' Search the right half
            Else
                right = mid - 1 ' Search the left half
            End If
        End While



        ' Target not found, return the index where it should be inserted
        Return left
    End Function

End Class

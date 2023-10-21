Public Class EightPuzzle
    '0 1 2
    '3 4 5
    '6 7 8
    Dim blankLocation As Integer = 4
    Public boardArray = New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8}
    Public boardArraySolution = New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8}

    Public Sub New()
        Dim blnArray(8) As Boolean

        ' Initialize the random-number generator.
        Randomize()
        For i As Integer = 0 To 8
            ' Generate random value between
            Dim value As Integer = CInt(Int((9 * Rnd())))
            If Not blnArray(value) Then
                blnArray(value) = True
                'finish coding
            End If
        Next
    End Sub

    Public Sub New(puzzle As EightPuzzle)
        blankLocation = puzzle.blankLocation

        For i As Integer = 0 To 8
            boardArray(i) = puzzle.boardArray(i)
        Next
    End Sub

    'strategy: 1D array for representing the 8puzzle
    'for every move, swap two numbers
    'create a function that checks if solution
    Public Function Move(ByVal blankMove As String) As Boolean
        Select Case blankMove
            Case "u"
                If (blankLocation - 3) < 0 Then
                    Return False
                Else
                    Swap(blankLocation, blankLocation - 3)
                    blankLocation = blankLocation - 3
                    Return True
                End If
            Case "d"
                If (blankLocation + 3) > 8 Then
                    Return False
                Else
                    Swap(blankLocation, blankLocation + 3)
                    blankLocation = blankLocation + 3
                    Return True
                End If
            Case "l"
                If ((blankLocation Mod 3) - 1) < 0 Then
                    Return False
                Else
                    Swap(blankLocation, blankLocation - 1)
                    blankLocation = blankLocation - 1
                    Return True
                End If
            Case "r"
                If ((blankLocation Mod 3) + 1) > 2 Then
                    Return False
                Else
                    Swap(blankLocation, blankLocation + 1)
                    blankLocation = blankLocation + 1
                    Return True
                End If
        End Select

        Return False
    End Function

    Public Function IsLegalMove(ByVal blankMove As String)
        Select Case blankMove
            Case "u"
                If (blankLocation - 3) < 0 Then
                    Return False
                Else
                    Return True
                End If
            Case "d"
                If (blankLocation + 3) > 8 Then
                    Return False
                Else
                    Return True
                End If
            Case "l"
                If ((blankLocation Mod 3) - 1) < 0 Then
                    Return False
                Else
                    Return True
                End If
            Case "r"
                If ((blankLocation Mod 3) + 1) > 2 Then
                    Return False
                Else
                    Return True
                End If
        End Select

        Return False
    End Function

    Public Function Swap(ByVal index1 As Integer, ByVal index2 As Integer)
        Dim tempVal As Integer = boardArray(index1)
        boardArray(index1) = boardArray(index2)
        boardArray(index2) = tempVal

        Return True
    End Function
End Class

Public Class EightPuzzle
    '0 1 2
    '3 4 5
    '6 7 8
    Public blankLocation As Integer = 4
    Public boardArray() As Integer = New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8}
    Public moves As List(Of String) = New List(Of String)
    'Public boardArrayMoves As List(Of Integer()) = New List(Of Integer())

    Public Sub New()

        ' Initialize the random-number generator.
        Randomize()
        Dim count As Integer = 0
        While (count < 25)
            Dim randMove As Integer = CInt(Int((4 * Rnd())))
            Select Case randMove
                Case 0
                    If Not IsLegalMove("u") Then
                        Continue While
                    End If
                    Move("u")
                    count += 1
                Case 1
                    If Not IsLegalMove("l") Then
                        Continue While
                    End If
                    Move("l")
                    count += 1
                Case 2
                    If Not IsLegalMove("r") Then
                        Continue While
                    End If
                    Move("r")
                    count += 1
                Case 3
                    If Not IsLegalMove("d") Then
                        Continue While
                    End If
                    Move("d")
                    count += 1
            End Select
        End While
    End Sub


    Public Sub New(ByVal puzzle As EightPuzzle)
        blankLocation = puzzle.blankLocation

        For i As Integer = 0 To 8
            boardArray(i) = puzzle.boardArray(i)
        Next

        For i As Integer = 0 To puzzle.moves.Count - 1
            moves.Add(puzzle.moves(i))
            ' Dim boardArray2(8) As Integer
            'Array.Copy(puzzle.boardArray, boardArray2, puzzle.boardArray.Length)
            'boardArrayMoves.Add(boardArray2)
        Next
    End Sub



    'strategy: 1D array for representing the 8puzzle
    'for every move, swap two numbers
    'create a function that checks if solution
    Public Function Move(ByVal blankMove As String) As Boolean
        If Not IsLegalMove(blankMove) Then
            Return False
        End If
        Select Case blankMove
            Case "u"
                Swap(blankLocation, blankLocation - 3)
                blankLocation = blankLocation - 3
                moves.Add(blankMove)
                'Dim boardArray2(8) As Integer
                '  Array.Copy(boardArray, boardArray2, boardArray.Length)
                'boardArrayMoves.Add(boardArray2)

                'debug
                'If Array.IndexOf(boardArray, 4) <> blankLocation Then
                '    blankLocation = blankLocation
                'End If

                Return True
            Case "d"
                Swap(blankLocation, blankLocation + 3)
                    blankLocation = blankLocation + 3
                moves.Add(blankMove)

                '  Dim boardArray2(8) As Integer
                ' Array.Copy(boardArray, boardArray2, boardArray.Length)
                'boardArrayMoves.Add(boardArray2)

                ''debug
                'If Array.IndexOf(boardArray, 4) <> blankLocation Then
                '    blankLocation = blankLocation
                'End If

                Return True
            Case "l"
                Swap(blankLocation, blankLocation - 1)
                    blankLocation = blankLocation - 1
                moves.Add(blankMove)

                'Dim boardArray2(8) As Integer
                'Array.Copy(boardArray, boardArray2, boardArray.Length)
                'boardArrayMoves.Add(boardArray2)

                ''debug
                'If Array.IndexOf(boardArray, 4) <> blankLocation Then
                '    blankLocation = blankLocation
                'End If

                Return True
            Case "r"
                Swap(blankLocation, blankLocation + 1)
                blankLocation = blankLocation + 1
                moves.Add(blankMove)

                'Dim boardArray2(8) As Integer
                'Array.Copy(boardArray, boardArray2, boardArray.Length)
                'boardArrayMoves.Add(boardArray2)

                ''debug
                'If Array.IndexOf(boardArray, 4) <> blankLocation Then
                '    blankLocation = blankLocation
                'End If

                Return True
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

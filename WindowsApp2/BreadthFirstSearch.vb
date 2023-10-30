Public Class BreadthFirstSearch
    Dim eightPuzzle As EightPuzzle
    Public queue As Queue(Of EightPuzzle) = New Queue(Of EightPuzzle)()

    Public Sub New(ByRef puzzle As EightPuzzle)
        eightPuzzle = New EightPuzzle(puzzle)
        eightPuzzle.moves = New List(Of String)
        'eightPuzzle.boardArrayMoves = New List(Of Integer())
        queue.Enqueue(eightPuzzle)
    End Sub

    Public Function FindSolution()
        While queue.Count > 0
            'eightPuzzle = bfs.queue.Dequeue()
            Dim nodeExpanded As EightPuzzle = ExpandNode()
            If IsSolution(nodeExpanded) Then
                Return nodeExpanded
                Exit While
            End If
        End While
        Return Nothing
    End Function

    Public Function IsSolution(ByVal puzzle As EightPuzzle) As Boolean
        For i As Integer = 0 To 8
            If puzzle.boardArray(i) <> i Then
                Return False
            End If
        Next

        Return True
    End Function


    Public Function ExpandNode() As EightPuzzle
        If queue.Count <> 0 Then
            Dim nodeToExpand As EightPuzzle = queue.Dequeue()


            'Execute all legal moves
            If nodeToExpand.IsLegalMove("u") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("u")
                queue.Enqueue(node2)
            End If

            If nodeToExpand.IsLegalMove("d") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("d")
                queue.Enqueue(node2)
            End If

            If nodeToExpand.IsLegalMove("l") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("l")
                queue.Enqueue(node2)
            End If

            If nodeToExpand.IsLegalMove("r") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("r")
                queue.Enqueue(node2)

            End If

            Return nodeToExpand
        End If

        Return Nothing


    End Function
End Class

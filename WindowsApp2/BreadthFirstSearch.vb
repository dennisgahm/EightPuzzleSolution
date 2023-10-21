Public Class BreadthFirstSearch
    Dim eightPuzzle As EightPuzzle
    Public queue As Queue(Of EightPuzzle) = New Queue(Of EightPuzzle)()

    Public Sub New(ByRef puzzle As EightPuzzle)
        eightPuzzle = puzzle
        queue.Enqueue(eightPuzzle)
    End Sub


    Public Sub ExpandNode()
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
        End If


    End Sub
End Class

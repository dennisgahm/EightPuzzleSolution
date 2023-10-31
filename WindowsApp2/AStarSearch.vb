Public Class AStarSearch

    Dim eightPuzzle As EightPuzzle
    Public priorityQueue As SortedList(Of Integer, EightPuzzle) = New SortedList(Of Integer, EightPuzzle)(New DuplicateKeyComparer())
    Public numNodesExpanded As Integer = 0

    Public Sub New(ByRef puzzle As EightPuzzle)
        eightPuzzle = New EightPuzzle(puzzle)
        eightPuzzle.moves = New List(Of String)
        'eightPuzzle.boardArrayMoves = New List(Of Integer())
        priorityQueue.Add(0, eightPuzzle)
    End Sub

    Public Function FindSolution()
        numNodesExpanded = 0
        While priorityQueue.Count > 0
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

    Public Function CalculateF(ByVal puzzle As EightPuzzle) As Integer
        Dim g_value As Integer = puzzle.moves.Count
        'Calculate h value
        Dim h_value As Integer = CalculateHManHattanDistance(puzzle)

        Return g_value + h_value

    End Function

    Public Function CalculateHManHattanDistance(ByVal puzzle As EightPuzzle) As Integer
        Dim hValue As Integer = 0
        For i As Integer = 0 To 8
            'distance
            Dim tileNumber As Integer = puzzle.boardArray(i)
            Dim horizontalDistance As Integer = Math.Abs(((i Mod 3) - tileNumber))

            Dim doubleI As Double = i
            Dim VerticalDistance As Integer = Math.Abs((Math.Floor(doubleI / 3.0) - tileNumber))

            hValue += horizontalDistance + VerticalDistance
        Next

        Return hValue
    End Function

    Public Function ExpandNode() As EightPuzzle
        If priorityQueue.Count <> 0 Then
            Dim nodeToExpand As EightPuzzle = priorityQueue.ElementAt(0).Value
            priorityQueue.RemoveAt(0)
            numNodesExpanded += 1


            'Execute all legal moves
            If nodeToExpand.IsLegalMove("u") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("u")
                priorityQueue.Add(CalculateF(node2), node2)
            End If

            If nodeToExpand.IsLegalMove("d") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("d")
                priorityQueue.Add(CalculateF(node2), node2)
            End If

            If nodeToExpand.IsLegalMove("l") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("l")
                priorityQueue.Add(CalculateF(node2), node2)
            End If

            If nodeToExpand.IsLegalMove("r") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("r")
                priorityQueue.Add(CalculateF(node2), node2)

            End If

            Return nodeToExpand
        End If

        Return Nothing


    End Function
End Class

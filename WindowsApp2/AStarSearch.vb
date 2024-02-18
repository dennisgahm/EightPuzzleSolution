'give the option to use manhattan distance or misplaced tiles


Public Class AStarSearch

    Dim eightPuzzle As EightPuzzle
    Public priorityQueue As SortedList(Of Integer, EightPuzzle) = New SortedList(Of Integer, EightPuzzle)(New DuplicateKeyComparer())
    Public numNodesExpanded As Integer = 0
    Public typeOfSearch As Integer = 0 '0 = manhattan distance, 1 = misplaced tiles
    Public puzzleOrganizer As EightPuzzleOrganizer = New EightPuzzleOrganizer()

    'specify typeOfSearch as parameter
    Public Sub New(ByRef puzzle As EightPuzzle, searchType As Integer)
        eightPuzzle = New EightPuzzle(puzzle)
        eightPuzzle.moves = New List(Of String)
        'eightPuzzle.boardArrayMoves = New List(Of Integer())
        priorityQueue.Add(0, eightPuzzle)
        puzzleOrganizer.Add(eightPuzzle)
        typeOfSearch = searchType
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
        'Give the option to use misplaced tiles or manhattan distance
        Dim h_value As Integer = 0
        If typeOfSearch = 1 Then
            h_value = CalculateHMisplacedTiles(puzzle)
        ElseIf typeOfSearch = 0 Then
            h_value = CalculateHManHattanDistance(puzzle)
        End If

        Return g_value + h_value

    End Function

    'Create a function for a heuristic for misplaced tiles
    Public Function CalculateHMisplacedTiles(ByVal puzzle As EightPuzzle) As Integer
        Dim hValue As Integer = 0
        For i As Integer = 0 To 8
            If puzzle.boardArray(i) <> i Then
                hValue += 1
            End If
        Next

        Return hValue
    End Function

    Public Function CalculateHManHattanDistance(ByVal puzzle As EightPuzzle) As Integer
        Dim hValue As Integer = 0
        For i As Integer = 0 To 8
            'distance
            Dim tileNumber As Integer = puzzle.boardArray(i)
            Dim horizontalDistance As Integer = Math.Abs(((i Mod 3) - (tileNumber Mod 3)))

            Dim doubleI As Double = i
            Dim VerticalDistance As Integer = Math.Abs((Math.Floor(doubleI / 3.0) - (Math.Floor(tileNumber / 3.0))))

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

                If (puzzleOrganizer.BinarySearch(node2) = -1) Then
                    priorityQueue.Add(CalculateF(node2), node2)
                    puzzleOrganizer.Add(node2)
                End If

            End If

            If nodeToExpand.IsLegalMove("d") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("d")
                If (puzzleOrganizer.BinarySearch(node2) = -1) Then
                    priorityQueue.Add(CalculateF(node2), node2)
                    puzzleOrganizer.Add(node2)
                End If
            End If

            If nodeToExpand.IsLegalMove("l") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("l")
                If (puzzleOrganizer.BinarySearch(node2) = -1) Then
                    priorityQueue.Add(CalculateF(node2), node2)
                    puzzleOrganizer.Add(node2)
                End If
            End If

            If nodeToExpand.IsLegalMove("r") Then
                Dim node2 As EightPuzzle = New EightPuzzle(nodeToExpand)
                node2.Move("r")
                If (puzzleOrganizer.BinarySearch(node2) = -1) Then
                    priorityQueue.Add(CalculateF(node2), node2)
                    puzzleOrganizer.Add(node2)
                End If

            End If

            Return nodeToExpand
        End If

        Return Nothing


    End Function
End Class

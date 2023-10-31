Public Class Form1
    Dim eightPuzzle As EightPuzzle
    Dim eightPuzzleSolutionBFS As EightPuzzle
    Dim eightPuzzleSolutionAStar As EightPuzzle
    Dim initialEightPuzzle As EightPuzzle
    Dim bfs As BreadthFirstSearch
    Dim a_star_search As AStarSearch

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        eightPuzzle = New EightPuzzle()
        'eightPuzzle.boardArray = {4, 1, 2, 0, 3, 5, 6, 7, 8}
        initialEightPuzzle = New EightPuzzle(eightPuzzle)

        'UpdateRichTextBox()

        'Test BFS search
        bfs = New BreadthFirstSearch(eightPuzzle)
        eightPuzzleSolutionBFS = bfs.FindSolution()
        'Do a real search until solution is found

        'Test BFS search
        a_star_search = New AStarSearch(eightPuzzle)
        eightPuzzleSolutionAStar = a_star_search.FindSolution()

        PrintSolution()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        'Select Case e.KeyCode

        '    Case Keys.Left
        '        eightPuzzle.Move("l")
        '    Case Keys.Up
        '        eightPuzzle.Move("u")
        '    Case Keys.Down
        '        eightPuzzle.Move("d")
        '    Case Keys.Right
        '        eightPuzzle.Move("r")
        '    Case Keys.Space
        '        If bfs.queue.Count > 0 Then
        '            'eightPuzzle = bfs.queue.Dequeue()
        '        End If
        'End Select

        'UpdateRichTextBox()

    End Sub

    Private Sub UpdateRichTextBox()
        'RichTextBox1.Text = ""
        'RichTextBox1.AppendText(eightPuzzle.boardArray(0) & eightPuzzle.boardArray(1) & eightPuzzle.boardArray(2) & vbNewLine)
        'RichTextBox1.AppendText(eightPuzzle.boardArray(3) & eightPuzzle.boardArray(4) & eightPuzzle.boardArray(5) & vbNewLine)
        'RichTextBox1.AppendText(eightPuzzle.boardArray(6) & eightPuzzle.boardArray(7) & eightPuzzle.boardArray(8) & vbNewLine)

    End Sub

    Private Sub PrintSolution()

        RichTextBox1.Text = ""
        RichTextBox1.AppendText("BFS: " & vbNewLine & "Number of node expansions: " & bfs.numNodesExpanded & vbNewLine & vbNewLine)

        Dim eightPuzzleCurrent As EightPuzzle = New EightPuzzle(initialEightPuzzle)
        For i As Integer = 0 To eightPuzzleSolutionBFS.moves.Count - 1
            RichTextBox1.AppendText("Board #" & i & " " & eightPuzzleSolutionBFS.moves(i) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine & vbNewLine)

            eightPuzzleCurrent.Move(eightPuzzleSolutionBFS.moves(i))
        Next

        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine)

        RichTextBox1.AppendText(vbNewLine & vbNewLine)

        RichTextBox1.AppendText("A*: " & vbNewLine & "Number of node expansions: " & a_star_search.numNodesExpanded & vbNewLine & vbNewLine)

        eightPuzzleCurrent = New EightPuzzle(initialEightPuzzle)
        For i As Integer = 0 To eightPuzzleSolutionAStar.moves.Count - 1
            RichTextBox1.AppendText("Board #" & i & " " & eightPuzzleSolutionAStar.moves(i) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine & vbNewLine)

            eightPuzzleCurrent.Move(eightPuzzleSolutionAStar.moves(i))
        Next

        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = ""
        PrintSolution()

        'If Array.IndexOf(initialEightPuzzle.boardArray, 4) <> initialEightPuzzle.blankLocation Then
        '    initialEightPuzzle.blankLocation = initialEightPuzzle.blankLocation
        'End If
    End Sub
End Class

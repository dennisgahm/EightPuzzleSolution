Public Class Form1
    Dim eightPuzzle As EightPuzzle
    Dim eightPuzzleSolution As EightPuzzle
    Dim initialEightPuzzle As EightPuzzle
    Dim bfs As BreadthFirstSearch

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        eightPuzzle = New EightPuzzle()
        'eightPuzzle.boardArray = {4, 1, 2, 0, 3, 5, 6, 7, 8}
        initialEightPuzzle = New EightPuzzle(eightPuzzle)

        'UpdateRichTextBox()

        'Test BFS search
        bfs = New BreadthFirstSearch(eightPuzzle)
        eightPuzzleSolution = bfs.FindSolution()
        'Do a real search until solution is found


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

        Dim eightPuzzleCurrent As EightPuzzle = New EightPuzzle(initialEightPuzzle)
        For i As Integer = 0 To eightPuzzleSolution.moves.Count - 1
            RichTextBox1.AppendText("Board #" & i & " " & eightPuzzleSolution.moves(i) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
            RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine & vbNewLine)

            eightPuzzleCurrent.Move(eightPuzzleSolution.moves(i))
        Next

        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(0) & eightPuzzleCurrent.boardArray(1) & eightPuzzleCurrent.boardArray(2) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(3) & eightPuzzleCurrent.boardArray(4) & eightPuzzleCurrent.boardArray(5) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzleCurrent.boardArray(6) & eightPuzzleCurrent.boardArray(7) & eightPuzzleCurrent.boardArray(8) & vbNewLine)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintSolution()

        If Array.IndexOf(initialEightPuzzle.boardArray, 4) <> initialEightPuzzle.blankLocation Then
            initialEightPuzzle.blankLocation = initialEightPuzzle.blankLocation
        End If
    End Sub
End Class

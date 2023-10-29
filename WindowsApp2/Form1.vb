Public Class Form1
    Dim eightPuzzle As EightPuzzle
    Dim bfs As BreadthFirstSearch

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        eightPuzzle = New EightPuzzle()
        eightPuzzle.boardArray = {4, 1, 2, 0, 3, 5, 6, 7, 8}
        eightPuzzle.blankLocation = 0
        UpdateRichTextBox()

        'Test BFS search
        bfs = New BreadthFirstSearch(eightPuzzle)

        'Do a real search until solution is found
        While bfs.queue.Count > 0
            'eightPuzzle = bfs.queue.Dequeue()
            Dim nodeExpanded As EightPuzzle = bfs.ExpandNode()
            If bfs.IsSolution(nodeExpanded) Then
                eightPuzzle = nodeExpanded
                UpdateRichTextBox()
                Exit While
            End If
        End While
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        Select Case e.KeyCode

            Case Keys.Left
                eightPuzzle.Move("l")
            Case Keys.Up
                eightPuzzle.Move("u")
            Case Keys.Down
                eightPuzzle.Move("d")
            Case Keys.Right
                eightPuzzle.Move("r")
            Case Keys.Space
                If bfs.queue.Count > 0 Then
                    'eightPuzzle = bfs.queue.Dequeue()
                End If
        End Select

        UpdateRichTextBox()

    End Sub

    Private Sub UpdateRichTextBox()
        RichTextBox1.Text = ""
        RichTextBox1.AppendText(eightPuzzle.boardArray(0) & eightPuzzle.boardArray(1) & eightPuzzle.boardArray(2) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzle.boardArray(3) & eightPuzzle.boardArray(4) & eightPuzzle.boardArray(5) & vbNewLine)
        RichTextBox1.AppendText(eightPuzzle.boardArray(6) & eightPuzzle.boardArray(7) & eightPuzzle.boardArray(8) & vbNewLine)

    End Sub
End Class

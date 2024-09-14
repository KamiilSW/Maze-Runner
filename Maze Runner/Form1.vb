Public Class Form1
    Dim gridSize As Integer = 50 'Amount of rows and columns!
    Dim cellSize As Integer = 10 ' Size of cells!
    Private Panel1 As New Panel()
    Private CellsOnEdge As New List(Of PictureBox) ' List to hold edge cells

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(10, 10) ' Puts the panel's location at this point
        Panel1.Size = New Size(gridSize * cellSize, gridSize * cellSize)
        Me.Controls.Add(Panel1)

        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                Dim cell As New PictureBox()

                ' Gives the cells properties
                cell.Size = New Size(cellSize, cellSize)
                cell.Location = New Point(j * cellSize, i * cellSize)
                cell.BackColor = Color.DarkSlateGray

                ' Adds the PictureBox to the panel controls.
                Panel1.Controls.Add(cell)

                'Add edge cells to the list
                If i = 0 OrElse i = gridSize - 1 OrElse j = 0 OrElse j = gridSize - 1 Then
                    CellsOnEdge.Add(cell)
                End If

                FindMiddle(cell)
                CreateBranches(cell)
            Next
        Next
        CreateExit()
    End Sub

    ' CHanges the middle cell's colour.
    Sub FindMiddle(ByRef cell As PictureBox)
        Dim middle As Integer = (gridSize / 2) - 1 ' Finds the middle
        If cell.Location = New Point(middle * cellSize, middle * cellSize) Then
            cell.BackColor = Color.LightGray ' Middle cell changes color to white
        End If
    End Sub
    Sub CreateBranches(ByRef cell As PictureBox)
        Dim random As New Random()
        Dim randomCoordX As Integer ' Create random x coord
        Dim randomCoordY As Integer ' Create random y coord
        Dim counter As Integer = 0

        Do
            randomCoordX = random.Next(0, gridSize - 1) * cellSize ' Gives x and y coords values
            randomCoordY = random.Next(0, gridSize - 1) * cellSize

            If cell.Location = New Point(randomCoordX, randomCoordY) Then ' If the cell location is the same as the random point then change its colour.
                cell.BackColor = Color.LightGray
                If CellsOnEdge.Contains(cell) Then
                    cell.BackColor = Color.DarkSlateGray 'If it is on the edge, change it back as we only want one exit.
                End If
            End If
            counter += 1
        Loop Until counter = 12 ' Only create 12 branches
    End Sub
    ' Changes one of the random cells on the edge.
    Sub CreateExit()
        Dim rand As New Random()
        'Selects a cell randomly from the Cellsonedge list
        Dim randomCellOnEdge As PictureBox = CellsOnEdge(rand.Next(CellsOnEdge.Count))
        randomCellOnEdge.BackColor = Color.LightGray
    End Sub

    Sub CreateExitPath(ByRef cell)
        Dim middleCell As PictureBox
        Dim middle As Integer = (gridSize / 2) - 1 'Integer used for middle coords
        Dim exitCell As PictureBox ' exitCell used to hold the cell for the exit to the maze.

        If CellsOnEdge(cell).BackColor = Color.LightGray Then
            exitCell = CellsOnEdge(cell) 'If the cell on the edge is light gray then assign it to exitCell PictureBox
        End If

        Dim counter As Integer = 0
        Dim leftCell As PictureBox



        If cell.Location = New Point(middle * cellSize, middle * cellSize) And cell.BackColor = Color.LightGray Then ' If the cell is in the middle and light gray (as a second measure) then assign it to the middleCell PictureBox
            middleCell = cell

            If cell.Location.X = middleCell.Location.X - cellSize And cell.Location.Y = middleCell.Location.Y Then
                leftCell = cell
                If MoveLeftPossible(middleCell, cell) = True Then
                    leftCell.BackColor = Color.LightGray
                End If
            End If

            'MoveLeftPossible(middleCell, cell)
            'MoveRightPossible()
            'MoveUpPossible()
            'MoveDownPossible()


            'Dim rand As New Random()
            'Dim highestRand As Integer = counter
            'Dim number As Integer = rand.Next(0, highestRand)
        End If



    End Sub

    Function MoveLeftPossible(middleCell, cell)
        Dim leftCellXCoord As Integer = middleCell.Location.X - cellSize
        Dim leftCell As PictureBox
        Dim tempCell As PictureBox
        Dim counter As Integer = 0

        If cell.Location.Y = middleCell And cell.Location.X = leftCellXCoord Then ' Checks leftCell
            leftCell = cell
            If leftCell.BackColor = Color.DarkSlateGray Then
                counter += 1
            End If
        End If

        If cell.Location.Y = middleCell.Location.Y - cellSize And cell.Location.X = leftCellXCoord Then ' Checks above leftCell
            tempCell = cell
            If tempCell.BackColor = Color.DarkSlateGray Then
                counter += 1
            End If
        End If

        If cell.Location.Y = middleCell.Location.Y + cellSize And cell.Location.X = leftCellXCoord Then ' Checks below leftCell
            tempCell = cell
            If tempCell.BackColor = Color.DarkSlateGray Then
                counter += 1
            End If
        End If

        If cell.Location.Y = middleCell.Location.Y And cell.Location.X = leftCellXCoord - cellSize Then ' Checks to the left of the leftCell
            tempCell = cell
            If tempCell.BackColor = Color.DarkSlateGray Then
                counter += 1
            End If
        End If

        If counter = 4 Then
            Return counter
            Return True
        Else
            Return False
        End If
    End Function

    Sub MoveRightPossible()

    End Sub

    Sub MoveUpPossible()

    End Sub

    Sub MoveDownPossible()

    End Sub
    Private Sub PictureBox_BackColorChanged(control As Object, e As EventArgs)
        ' If a picturebox's colour is changed, this will react.
    End Sub
End Class

Imports System.IO
Imports System.Text

''' <summary>
''' Class to read a text file backwards.
''' </summary>
''' <remarks></remarks>
Public Class BackwardReader
    Implements IDisposable
    '*********************************************************************************************************************************
    '
    '             Class:  BackwardReader
    '      Initial Date:  11/29/2010
    '     Last Modified:  11/29/2010
    '     Programmer(s):  Original C# Source - the_real_herminator
    '                     http://social.msdn.microsoft.com/forums/en-US/csharpgeneral/thread/9acdde1a-03cd-4018-9f87-6e201d8f5d09
    '                     VB Converstion - Blake Pell
    '
    '*********************************************************************************************************************************
    Private _path As String = ""
    Private _fs As FileStream = Nothing
    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal path As String)
        _path = path
        _fs = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        _fs.Seek(0, SeekOrigin.[End])
    End Sub
    ''' <summary>
    ''' Read's the next line in.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadLine() As String
        Dim line As Byte()
        Dim text As Byte() = New Byte(0) {}
        Dim position As Long = 0
        Dim count As Integer = 0
        _fs.Seek(0, SeekOrigin.Current)
        position = _fs.Position
        'do we have trailing rn?
        If _fs.Length > 1 Then
            Dim vagnretur As Byte() = New Byte(1) {}
            _fs.Seek(-2, SeekOrigin.Current)
            _fs.Read(vagnretur, 0, 2)
            If ASCIIEncoding.ASCII.GetString(vagnretur).Equals(vbCr & vbLf) Then
                'move it back
                _fs.Seek(-2, SeekOrigin.Current)
                position = _fs.Position
            End If
        End If
        While _fs.Position > 0
            text.Initialize()
            'read one char
            _fs.Read(text, 0, 1)
            Dim asciiText As String = ASCIIEncoding.ASCII.GetString(text)
            'moveback to the charachter before
            _fs.Seek(-2, SeekOrigin.Current)
            If asciiText.Equals(vbLf) Then
                _fs.Read(text, 0, 1)
                asciiText = ASCIIEncoding.ASCII.GetString(text)
                If asciiText.Equals(vbCr) Then
                    _fs.Seek(1, SeekOrigin.Current)
                    Exit While
                End If
            End If
        End While
        count = Integer.Parse((position - _fs.Position).ToString())
        line = New Byte(count - 1) {}
        _fs.Read(line, 0, count)
        _fs.Seek(-count, SeekOrigin.Current)
        Return ASCIIEncoding.ASCII.GetString(line)
    End Function
    ''' <summary>
    ''' Whether or not the start of file has been reached.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SOF() As Boolean
        Get
            Return _fs.Position = 0
        End Get
    End Property
    ''' <summary>
    ''' Closes the FileStream and disposes of it's resources.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        _fs.Close() : _fs.Dispose()
    End Sub
    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
                Me.Close()
            End If
            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class

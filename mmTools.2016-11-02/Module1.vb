
REM ********************************************************************************************************************************************************************
Imports System.Text
REM ********************************************************************************************************************************************************************

REM ********************************************************************************************************************************************************************
Imports SongsDB
REM ********************************************************************************************************************************************************************

REM ********************************************************************************************************************************************************************
Module Module1
   REM ****************************************************************************************************************************************************************

   Public mm As SongsDB.SDBApplication = New SongsDB.SDBApplication()
   Public sl As New SDBSongList

   Sub Main()
      Dim Result As Boolean

      Do While 1 = 1
         sl = mm.AllVisibleSongList
         Result = LstCurTrk(sl)
      Loop

   End Sub

   Function LstCurTrk(sl As SDBSongList) As Boolean

      Dim sd As New SDBSongData
      Dim sdA As ISDBAlbum

      Dim slCnt As Integer = sl.Count - 1
      Dim Idx As Integer
      Dim AlbumHeader As New StringBuilder
      Dim TrackData As New StringBuilder

      Dim L1 As String = Nothing
      Dim L2 As String = Nothing
      Dim L3 As String = Nothing

      Dim CurLinLng As Integer = 0

      Console.WriteLine("Track-Übersicht")
      Console.WriteLine()

      For Idx = 0 To slCnt

         sd = sl.Item(Idx)
         sdA = sd.Album

         If L3 <> CStr(sd.AlbumArtistName) Then

            Console.WriteLine()

            AlbumHeader.Clear()
            AlbumHeader.Append("AlbumArtist: ")
            AlbumHeader.Append(Trim(CStr(sd.AlbumArtistName)))
            ChgConsBufLng(AlbumHeader.Length)
            Console.WriteLine(AlbumHeader.ToString)

            L3 = CStr(sd.AlbumArtistName)
            L2 = Nothing
            L1 = Nothing

         End If

         If L2 <> CStr(sdA.Name) Then

            Console.WriteLine()

            AlbumHeader.Clear()
            AlbumHeader.Append("Album: ")
            AlbumHeader.Append(Trim(CStr(sdA.Name)))
            ChgConsBufLng(AlbumHeader.Length)
            Console.WriteLine(AlbumHeader.ToString)

            AlbumHeader.Clear()
            AlbumHeader.Append("Erscheinungs-Datum: ")
            AlbumHeader.Append(Format(sd.Date, "yyyy-MM-dd"))
            ChgConsBufLng(AlbumHeader.Length)
            Console.WriteLine(AlbumHeader.ToString)

            L2 = CStr(sdA.Name)
            L1 = Nothing

         End If

         If L1 <> CStr(sd.DiscNumberStr) Then

            Console.WriteLine()

            L1 = CStr(sd.DiscNumberStr)

         End If

         TrackData.Clear()
         If sd.DiscNumber <> 0 Then
            TrackData.Append(Format(sd.DiscNumber, "00"))
            TrackData.Append(" ")
         End If

         TrackData.Append(Format(sd.TrackOrder, "00"))
         TrackData.Append(" ")
         TrackData.Append(sd.SongLengthString)
         TrackData.Append(" ")
         TrackData.Append(sd.Title)
         ChgConsBufLng(TrackData.Length)
         Console.WriteLine(TrackData.ToString)

      Next

      Return True

   End Function

   Function ChgConsBufLng(LinLng As Integer) As Boolean
      LinLng += 1
      If LinLng > Console.BufferWidth Then
         Console.BufferWidth = LinLng
      End If

      Return True

   End Function

End Module

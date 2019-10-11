## DracoonSDK

`Download:`[https://github.com/loudKode/DracoonSDK/releases](https://github.com/loudKode/DracoonSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.DracoonSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.DracoonSDK)<br>

**Features**
* Assemblies for .NET 4.5.2 and .NET Standard 2.0 and .NET Core 2.1
* Just one external reference (Newtonsoft.Json)
* Easy installation using NuGet
* Upload/Download tracking support
* Proxy Support
* Upload/Download cancellation support


# List of functions:
* GetParents
* TestServerConnection
* TestTokenValidation
* LoggedIn
* CreateOAuthClient
* GetOAuthClient
* Search
* SearchRoom
* FilterByExtensions
* FilterByClassifications
* FilterBySize
* SearchByPath
* UserInfo
* AcceptEULA
* RevokeToken
* GetFileDownloadUrl
* FileMetadata
* FolderMetadata
* RoomMetadata
* GetRoomID
* GetFilesDownloadUrlAsZip
* CreateNewFolder
* ListRooms
* ListRoot
* DeleteFile
* DeleteFolder
* DeleteRoom
* DeleteFileFolder
* DeleteMultipleFiles
* DeleteMultipleFolders
* DeleteMultipleFilesFolders
* DeleteMultipleRooms
* RenameFolder
* RenameFile
* ChangeFileClassification
* ChangeFolderClassification
* CreateRoom
* EditRoomNameOrQuota
* AddUserToRoom
* DeleteUserFromRoom
* DeleteMultipleUsersFromRoom
* DownloadFile
* DownloadFileAsStream
* DownloadMultipleFilesAsZip
* GetUploadLink
* UploadLocalFile
* GetHomeRoomSettings
* SetHomeRoomSettings
* CopyFile
* CopyAndRenameFile
* CopyMultipleFiles
* CopyFolder
* CopyAndRenameFolder
* CopyMultipleFolders
* CopyFileFolder
* CopyAndRenameFileFolder
* CopyMultipleFilesFolders
* MoveFile
* MoveAndRenameFile
* MoveMultipleFiles
* MoveFolder
* MoveAndRenameFolder
* MoveMultipleFolders
* MoveFileFolder
* MoveAndRenameFileFolder
* MoveMultipleFilesFolders
* ListTrashedFilesFolders
* EmptyRecycleBin
* Bookmark
* UnBookmark
* ListBookmarks
* ListShares
* ShareFileFolder
* UnShareFileFolder
* ShareInfo


# Code simple:
```vb
Async Sub GetToken()
        Dim tkn = Await DracoonSDK.GetToken.GetToken("user", "pass")
        DataGridView1.Rows.Add(tkn.token)
    End Sub
```
```vb
    Sub SetClient()
        Dim MyClient As DracoonSDK.IClient = New DracoonSDK.DClient("token")
    End Sub
```
```vb
    Sub SetClientWithOptions()
        Dim Optians As New DracoonSDK.ConnectionSettings With {.CloseConnection = True, .TimeOut = TimeSpan.FromMinutes(30), .Proxy = New DracoonSDK.ProxyConfig With {.ProxyIP = "172.0.0.0", .ProxyPort = 80, .ProxyUsername = "myname", .ProxyPassword = "myPass", .SetProxy = True}}
        Dim MyClient As DracoonSDK.IClient = New DracoonSDK.DClient("access token", Optians)
    End Sub
```
```vb
    Async Sub ListMyRooms()
        Dim result = Await MyClient.Data.Room.List(10, 0, SortEnum.name, OrderEnum.asc)
        For Each vid In result.RoomsList
            DataGridView1.Rows.Add(vid.name, vid.id, vid.size, vid.permissions.create)
        Next
    End Sub
```
```vb
    Async Sub ListMyFilesAndFolders()
        Dim fltr As New DracoonSDK.DataClient.List_root_Filtering
        fltr.type.FilesFolders = FilesFoldersEnum.both
        Dim result = Await MyClient.Data.List(fltr, "room or folder id", 50, 0, SortEnum.name, OrderEnum.asc)
        For Each vid In result.itemsList
            DataGridView1.Rows.Add(vid.name, vid.id, vid.size, vid.permissions.create, vid.parentId)
        Next
    End Sub
```
```vb
    Async Sub DeleteFileOrFolder()
        Dim result = Await MyClient.Data.Delete("file or folder id")
    End Sub
```
```vb
    Async Sub MoveFileOrFolder()
        Dim result = Await MyClient.Data.Move("file id", "folder id", Nothing, ResolutionStrategyEnum.autorename)
    End Sub
```
```vb
    Async Sub CreateNewFolder()
        Dim result = Await MyClient.Data.Folder.Create("parent folder id", "new folder name")
    End Sub
```
```vb
    Async Sub GetRoomMetadata()
        Dim result = Await MyClient.Data.Room.Metadata("room id")
    End Sub
```
```vb
    Async Sub GetFilesDownloadUrlAsZip()
        Dim result = Await MyClient.Share.GetFilesDownloadUrlAsZip(New List(Of Integer) From {"file id", "file id"})
        DataGridView1.Rows.Add(result.downloadUrl, result.token)
    End Sub
```
```vb
    Async Sub CreateNewRoom()
        Dim result = Await MyClient.Data.Room.Create("room id", ClassificationEnum.Public, "my user id")
    End Sub
```
```vb
    Async Sub SearchAFile()
        Dim result = Await MyClient.Search.SearchRoom("room id", "ureWiz.png", FilesFoldersEnum.file, -1, 20, 0, SortEnum.name, OrderEnum.asc)
        For Each onz In result.itemsList
            DataGridView1.Rows.Add(onz.name, onz.File_Folder.ToString, onz.size)
        Next
    End Sub
```
```vb
    Async Sub FilterByExtensions()
        Dim RSLT = Await MyClient.Search.FilterByExtensions("file id", "png", FormulaEnum.eq, -1, 20, 0, SortEnum.name, OrderEnum.asc)
        For Each onz In RSLT.itemsList
            DataGridView1.Rows.Add(onz.name, onz.File_Folder.ToString, ISisFunctions.Bytes_To_KbMbGb.SetBytes(onz.size))
        Next
    End Sub
```
```vb
    Private Async Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        Dim fltr As New DracoonSDK.ShareClient.List_Shares_Filtering
        fltr.name.NameKeyword = "my"
        Dim RSLT = Await MyClient.Share.List(fltr, 20, 0, SortEnum.name, OrderEnum.asc)
        For Each onz In RSLT.items
            DataGridView1.Rows.Add(onz.ShareID, onz.ID, onz.name, onz.nodePath, onz.isEncrypted, onz.isPasswordProtected, onz.accessKey, onz.cntDownloads, onz.smsRecipients, onz.ShareUrl)
        Next
    End Sub
```
```vb
    Async Sub Upload_Local_WithProgressTracking()
        Dim UploadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of DracoonSDK.ReportStatus)(Sub(ReportClass As DracoonSDK.ReportStatus)
                                                                       Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                       ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                       Label2.Text = CStr(ReportClass.TextStatus)
                                                                   End Sub)
        Await MyClient.Data.File.Upload("J:\DB\myvideo.mp4", UploadTypes.FilePath, "myvideo.mp4", "folder id", ClassificationEnum.Internal, _ReportCls, UploadCancellationToken.Token)
    End Sub
```
```vb
    Async Sub Download_File_WithProgressTracking()
        Dim DownloadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of DracoonSDK.ReportStatus)(Sub(ReportClass As DracoonSDK.ReportStatus)
                                                                       Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                       ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                       Label2.Text = CStr(ReportClass.TextStatus)
                                                                   End Sub)
        Await MyClient.Data.File.Download("file id", "J:\DB\", "myvideo.mp4", _ReportCls, DownloadCancellationToken.Token)
    End Sub
```
```vb
    Async Sub CreateNewDevApp()
        Dim RSLT = Await MyClient.Account.CreateOAuthClient("NewTestDraClient", "https://MyDomain.org/Dracoon/app.html")
        DataGridView1.Rows.Add(RSLT.clientName, RSLT.clientId, RSLT.clientSecret, RSLT.grantTypes, RSLT.accessTokenValidity, RSLT.isEnabled, RSLT.isStandard, RSLT.redirectUris, RSLT.refreshTokenValidity)
    End Sub
```
```vb
    Async Sub AppInfo()
        Dim RSLT = Await MyClient.Account.GetOAuthClient()
        DataGridView1.Rows.Add(RSLT.clientName)
    End Sub
```

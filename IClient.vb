using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DracoonSDK.JSON;

namespace DracoonSDK
{
	public interface IClient
	{
		Task<JSON_GetParents> GetParents(int DestinationFileFolderID);

		Task<bool> TestServerConnection();

		Task<bool> TestTokenValidation();

		bool LoggedIn();

		Task<JSON_CreateOAuthClient> CreateOAuthClient(string ClientName, string RedirectUrl);

		Task<JSON_CreateOAuthClient> GetOAuthClient();

		Task<JSON_ListRoot> Search(string SearchKeywords, int FolderID, int SubDepthLevel, DClient.Search_Filtering SearchFiltering = null, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> SearchRoom(int RoomID, string SearchKeywords, DrAutilities.FilesFoldersEnum SearchType, int SubDepthLevel, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> FilterByExtensions(int FolderID, string Extension, DrAutilities.FormulaEnum Formula, int SubDepthLevel, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> FilterByClassifications(int FolderID, DrAutilities.FilesFoldersEnum SearchType, DrAutilities.ClassificationEnum Classification, int SubDepthLevel, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> FilterBySize(int FolderID, DrAutilities.FilesFoldersEnum SearchType, int SizeinByte, DrAutilities.SymbolsEnum Symbols, int SubDepthLevel, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> SearchByPath(int FolderID, DrAutilities.FilesFoldersEnum SearchType, string PathKeywords, DrAutilities.FormulaEnum Formula, int SubDepthLevel, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_UserInfo> UserInfo();

		Task<bool> AcceptEULA();

		Task<bool> RevokeToken();

		Task<JSON_GetFileDownloadUrl> GetFileDownloadUrl(int FileID);

		Task<JSON_FileMetadata> FileMetadata(int FileID);

		Task<JSON_FolderMetadata> FolderMetadata(int FolderID);

		Task<JSON_RoomMetadata> RoomMetadata(int RoomID);

		Task<int> GetRoomID(string RoomName);

		Task<JSON_GetFileDownloadUrl> GetFilesDownloadUrlAsZip(List<int> NodesIDs);

		Task<JSON_CreateNewFolder> CreateNewFolder(int DestinationFolderID, string FolderName);

		Task<JSON_ListRooms> ListRooms(int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListRoot> ListRoot(DClient.List_root_Filtering ListrootFiltering, string RoomFileFolderID = null, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<bool> DeleteFile(int FileID);

		Task<bool> DeleteFolder(int FolderID);

		Task<bool> DeleteRoom(int RoomID);

		Task<bool> DeleteFileFolder(int FileFolderID);

		Task<bool> DeleteMultipleFiles(List<int> FilesIDs);

		Task<bool> DeleteMultipleFolders(List<int> FoldersIDs);

		Task<bool> DeleteMultipleFilesFolders(List<int> FilesFoldersIDs);

		Task<bool> DeleteMultipleRooms(List<int> RoomsIDs);

		Task<JSON_FolderMetadata> RenameFolder(int FolderID, string NewName);

		Task<JSON_FileMetadata> RenameFile(int FileID, string NewName);

		Task<JSON_FileMetadata> ChangeFileClassification(int FileID, DrAutilities.ClassificationEnum Classification);

		Task<JSON_FolderMetadata> ChangeFolderClassification(int FolderID, DrAutilities.ClassificationEnum Classification);

		Task<JSON_RoomMetadata> CreateRoom(string RoomName, DrAutilities.ClassificationEnum Permissions, int AdminUserID);

		Task<JSON_RoomMetadata> EditRoomNameOrQuota(int RoomID, string NewName = null, int? Quota = null);

		Task<bool> AddUserToRoom(int RoomID, int UserID, JSON_Permissions SetPermissions);

		Task<bool> DeleteUserFromRoom(int RoomID, int UserID);

		Task<bool> DeleteMultipleUsersFromRoom(int RoomID, List<int> UsersIDs);

		Task DownloadFile(string FileID, string FileSaveDir, string FileName, IProgress<ReportStatus> ReportCls = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<Stream> DownloadFileAsStream(string FileID, IProgress<ReportStatus> ReportCls = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task DownloadMultipleFilesAsZip(List<int> NodesIDs, string FileSaveDir, string FileName, IProgress<ReportStatus> ReportCls = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<JSON_GetUploadLink> GetUploadLink(int DestinationFolderID, string UploadedName, string UploadedSize, DrAutilities.ClassificationEnum Permissions);

		Task<JSON_FileMetadata> UploadLocalFile(object FileToUpload, string DestinationFolderID, DrAutilities.ClassificationEnum Permissions, DClient.UploadTypes UploadType, string FileName, IProgress<ReportStatus> ReportCls = null, CancellationToken token = default(CancellationToken));

		Task<JSON_GetHomeRoomSettings> GetHomeRoomSettings();

		Task<JSON_SetHomeRoomSettings> SetHomeRoomSettings(string HomeRoomParentName, int QuotaInBytes, bool Active);

		Task<JSON_FileMetadata> CopyFile(int SorceFileID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileMetadata> CopyAndRenameFile(int SorceFileID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileMetadata> CopyMultipleFiles(List<int> SorceFilesIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> CopyFolder(int SorceFolderID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> CopyAndRenameFolder(int SorceFolderID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> CopyMultipleFolders(List<int> SorceFoldersIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> CopyFileFolder(int SorceFileFolderID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> CopyAndRenameFileFolder(int SorceFileFolderID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> CopyMultipleFilesFolders(List<int> SorceFilesFoldersIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileMetadata> MoveFile(int SorceFileID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileMetadata> MoveAndRenameFile(int SorceFileID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileMetadata> MoveMultipleFiles(List<int> SorceFilesIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> MoveFolder(int SorceFolderID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> MoveAndRenameFolder(int SorceFolderID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FolderMetadata> MoveMultipleFolders(List<int> SorceFoldersIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> MoveFileFolder(int SorceFileFolderID, int DestinationFolderID, string RenameTo = null, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> MoveAndRenameFileFolder(int SorceFileFolderID, int DestinationFolderID, string RenameTo, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_FileFolderMetadata> MoveMultipleFilesFolders(List<int> SorceFilesFoldersIDs, int DestinationFolderID, DrAutilities.ResolutionStrategyEnum? IfAlreadyExist = null);

		Task<JSON_ListTrashedFilesFolders> ListTrashedFilesFolders(int RoomID, DrAutilities.FilesFoldersEnum? FilesFolders = null, string containsKeywords = null, string PathKeywords = null, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListTrashedFilesFolders> EmptyRecycleBin(int RoomID);

		Task<JSON_FileFolderRoomMetadata> Bookmark(int ID);

		Task<bool> UnBookmark(int ID);

		Task<JSON_ListFavorite> ListBookmarks(DrAutilities.FilesFoldersEnum? FilesFolders = null, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_ListShares> ListShares(DClient.List_Shares_Filtering ListshareFiltering = null, int Limit = 50, int Offset = 0, DrAutilities.SortEnum? SortBy = null, DrAutilities.OrderEnum? Order = null);

		Task<JSON_SharesItem> ShareFileFolder(int FileFolderID, string PassWord = null, string NameShareTo = null, string MaxShareDownloads = null);

		Task<bool> UnShareFileFolder(int ShareID);

		Task<JSON_SharesItem> ShareInfo(int ShareID);
	}
}

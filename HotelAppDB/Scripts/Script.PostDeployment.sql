/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from [dbo].[RoomTypes])
begin
    insert into [dbo].[RoomTypes] ([Title], [Description], [Price])
    values 
        ('Single', 'A room with a single bed and a window.', 100),
        ('Double', 'A room with two beds and a window.', 200),
        ('King', 'A room with a king size bed and a window.', 300);
end

if not exists (select 1 from [dbo].[Rooms])
begin
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;

    select @roomId1 = [Id] from [dbo].[RoomTypes] where [Title] = 'Single';
    select @roomId2 = [Id] from [dbo].[RoomTypes] where [Title] = 'Double';
    select @roomId3 = [Id] from [dbo].[RoomTypes] where [Title] = 'King';

	insert into [dbo].[Rooms] ([RoomTypeId], [RoomNumber])
    values
        (@roomId1, '101'),
        (@roomId1, '102'),
        (@roomId1, '103'),
	    (@roomId2, '201'),
        (@roomId2, '202'),
	    (@roomId3, '301');
end

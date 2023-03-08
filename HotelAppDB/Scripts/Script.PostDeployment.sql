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
        ('Queen', 'A room with a queen-sized bed and a window.', 100),
        ('King', 'A room with a king size bed and a window.', 200),
        ('Twin', 'A room with two twin-sized beds and a window.', 300),
        ('Hollywood twin', 'A room with two twin beds that are joined by the same headboard and a window.', 400),
        ('Double-double', 'A room with two double beds and are meant to accommodate two to four people, especially families traveling with young kids.', 400),
        ('Studio', 'A fully-furnished apartment with a small kitchenette.', 500);
end

if not exists (select 1 from [dbo].[Rooms])
begin
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;
    declare @roomId4 int;
    declare @roomId5 int;
    declare @roomId6 int;


    select @roomId1 = [Id] from [dbo].[RoomTypes] where [Title] = 'Queen';
    select @roomId2 = [Id] from [dbo].[RoomTypes] where [Title] = 'King';
    select @roomId3 = [Id] from [dbo].[RoomTypes] where [Title] = 'Twin';
    select @roomId4 = [Id] from [dbo].[RoomTypes] where [Title] = 'Hollywood twin';
    select @roomId5 = [Id] from [dbo].[RoomTypes] where [Title] = 'Double-double';
    select @roomId6 = [Id] from [dbo].[RoomTypes] where [Title] = 'Studio';

	insert into [dbo].[Rooms] ([RoomTypeId], [RoomNumber])
    values
        (@roomId1, '101'),
        (@roomId1, '102'),
        (@roomId1, '103'),
	    (@roomId2, '201'),
        (@roomId2, '202'),
	    (@roomId3, '301'),
        (@roomId3, '302'),
		(@roomId3, '303'),
		(@roomId4, '401'),
		(@roomId4, '402'),
		(@roomId4, '403'),
		(@roomId5, '501'),
		(@roomId5, '502'),
		(@roomId5, '503'),
		(@roomId6, '601'),
		(@roomId6, '602'),
		(@roomId6, '603');
end

USE [Skillz]
GO

INSERT INTO [dbo].[Companies]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[Title]
           ,[IsDeleted])
     VALUES
           ('C0884A97-27BB-4DE7-96B2-C869ACFA8EA0'
           ,getdate()
           ,getdate()
           ,'Elmos NV.'
           ,0)
GO

INSERT INTO [dbo].[EvaluationQuestionTypes]
           ([Id]
           ,[Title]
           ,[Description]
           ,[IsDeleted])
     VALUES
             (newid(),'Text',NULL,0)
		   , (newid(),'Range',NULL,0)
GO

INSERT INTO [dbo].[EvaluationQuestionCategories]
           ([Id]
           ,[Title]
           ,[Description]
		   ,[CompanyId]
           ,[IsDeleted])
     VALUES
             (newid(),'Soft Skills',NULL, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',0)
           , (newid(),'Functievervulling',NULL, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',0)
		   , (newid(),'C# Skills',NULL, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',0)
		   , (newid(),'Testing Skills', NULL, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',0)
GO

INSERT INTO [dbo].[EvaluationQuestionGroups]
           ([Id]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId]
           ,[EvaluationQuestionParentGroupId])
     VALUES
             ('0DFD39FB-287D-4692-999E-D0608ED2D6EC','Functievervulling','Functievervulling', 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',NULL)
		   , ('F321D4B7-2687-43B9-BF64-12571E778DC0','Kennis','Kennis', 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0','0DFD39FB-287D-4692-999E-D0608ED2D6EC')
		   , ('0C8DD8E6-AC28-4008-867B-FB3093475D81','Kwaliteit van het werk','Kwaliteit van het werk', 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0','0DFD39FB-287D-4692-999E-D0608ED2D6EC')
		   , ('95701445-22C0-4F58-A0BC-1DF6D0515689','Persoonlijke inzet / houding',NULL, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0','0DFD39FB-287D-4692-999E-D0608ED2D6EC')
		   , ('79E667F1-FC58-47BB-9515-2E5796E1527F','Soft Skills', NULL, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',NULL)
		   , ('54A7AABA-F96B-465D-8F8E-826867C2CCFF','Taalgebruik',NULL, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0','79E667F1-FC58-47BB-9515-2E5796E1527F')
GO

USE [Skillz]
GO

INSERT INTO [dbo].[Roles]
           ([Id]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId])
     VALUES
             ('9AEFC80B-A52F-43FC-B123-C549E4461FAD' ,'CEO',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('8402F744-3B38-4FAB-A98A-D7799F998C37' ,'Competence Manager',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('9E25035F-63C7-4757-8BB8-FCF2BFC12ABE' ,'Sales Manager',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('9C2EF337-05BC-4A69-A89E-47F2AA118E36' ,'Recruitment Manager',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('0D1BA8D5-7AB1-4324-81FF-3C2A9F46C560' ,'Recruiter',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('0D66C55B-5F12-4BBE-B0EC-1090EADB622B' ,'Account Manager',NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')

GO

USE [Skillz]
GO

INSERT INTO [dbo].[Accounts]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[Title]
           ,[IsDeleted],
		   [CompanyId])
     VALUES
           ('63938D52-664A-4219-842B-4D6A00871A37',getdate(),getdate(), 'Het Grootste Licht', 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')

GO

USE [Skillz]
GO

INSERT INTO [dbo].[Perk]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId]
           ,[NetValue]
           ,[Tax]
           ,[CompanyCost])
     VALUES
             ('A9CA9A3C-46EE-453C-A49E-5CB7F3F01697', getdate(), GETDATE(), 'Auto', null, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0', 100, 21, 100) 
           , ('7DB2FEF1-393E-4E3E-868B-3A93061E1532', getdate(), GETDATE(), 'Tankkaart', null, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0', 100, 21, 100) 
		   , ('F19C4D81-098A-4C39-A610-C654EF3E2A79', getdate(), GETDATE(), 'Hospitalisatie verzekering', null, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0', 100, 21, 100) 
		   , ('B4D676DC-17BE-4F48-99C2-B611C7E1E655', getdate(), GETDATE(), 'Maaltijdchecks', null, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0', 100, 21, 100) 
			 		
GO

USE [Skillz]
GO

INSERT INTO [dbo].[Profiles]
           ([Id]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId])
     VALUES
           ('25FBEF3D-A833-4ABE-96AE-5A577AF7619D','Developer', NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('BA092B20-4665-4A18-9D27-539DF36941E0','Analyst', NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')

GO

USE [Skillz]
GO

INSERT INTO [dbo].[SkillGroups]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId]
           ,[ProfileId])


     VALUES
          ('EFE237DC-8779-42A0-95DC-7A5ACFCCC686', getdate(), GETDATE(), 'Programmeertalen', NULL, 0,'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0',  'B636A5B6-3D9B-47C2-89F3-EE55A31E5666')
	    , ('88601E3D-F927-42E0-9D40-88A55443E4B9', getdate(), GETDATE(), 'Tools', NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0','29963998-D2B8-4EEA-8647-7EDC7224138A')
GO



USE [Skillz]
GO

INSERT INTO [dbo].[Skills]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[Title]
           ,[Description]
           ,[IsDeleted]
           ,[CompanyId])
     VALUES
             ('29963998-D2B8-4EEA-8647-7EDC7224138A', getdate(), GETDATE(), 'C#' , NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('5CBBE31E-9A36-4843-A533-7F1D7B48DE75', getdate(), GETDATE(), 'Entity Framework', NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
		   , ('B636A5B6-3D9B-47C2-89F3-EE55A31E5666', getdate(), GETDATE(), 'BPMN', NULL, 0, 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0')
GO

USE [Skillz]
GO

INSERT INTO [dbo].[SkillGroupSkills]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[SkillId]
           ,[SkillGroupId])
     VALUES
           (newid(), getdate(), GETDATE(), '29963998-D2B8-4EEA-8647-7EDC7224138A', '88601E3D-F927-42E0-9D40-88A55443E4B9')

GO



USE [Skillz]
GO

INSERT INTO [dbo].[Consultants]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[Phone]
           ,[MobilePhone]
           ,[CompanyId]
           ,[IsDeleted]
           ,[IsActive]
           ,[Birthdate]
           ,[FunctionLevel]
           ,[FunctionName])
     VALUES
           ('A274BB4E-2350-4D37-80B2-6D6DE798143D', getdate(), GETDATE(), 'Jan', 'Tubeeckx', 'jan.tubeeckx@hotmail.com', '+32 (0)485 053421', '+32 (0)485 053421', 'C0884A97-27BB-4DE7-96B2-C869ACFA8EA0', 0, 1, NULL, 'Junior', 'Analayst')



GO


INSERT INTO [dbo].[SkillProfiles]
           ([Id]
           ,[Created]
           ,[Modified]
           ,[SkillId]
           ,[ProfileId])
     VALUES
          ('30C428B8-B51C-4AE4-A440-C3E44926F042', getdate(), GETDATE(), 'B636A5B6-3D9B-47C2-89F3-EE55A31E5666','BA092B20-4665-4A18-9D27-539DF36941E0')
	    , ('C412B0AD-B7A7-4D35-858D-029C595888AB', getdate(), GETDATE(), '29963998-D2B8-4EEA-8647-7EDC7224138A','25FBEF3D-A833-4ABE-96AE-5A577AF7619D')
		, ('1E1CA93E-FD01-4079-8E5B-1F01FB8DCFE4', getdate(), GETDATE(), '5CBBE31E-9A36-4843-A533-7F1D7B48DE75','25FBEF3D-A833-4ABE-96AE-5A577AF7619D')
GO


USE [Skillz]
GO


















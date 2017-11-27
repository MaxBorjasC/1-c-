

USE vega


SELECT * FROM [dbo].[Makes]

SELECT * FROM [dbo].[Models]

SELECT * FROM [dbo].[Features]

SELECT * FROM [dbo].[VehicleFeatures]

SELECT * FROM [dbo].[Vehicles]


--truncate table [dbo].[Makes]
--truncate table [dbo].[Models]
--truncate table [dbo].[Features]
--truncate table [dbo].[VehicleFeatures]
--truncate table [dbo].[Vehicles]


INSERT INTO Makes (Name) VALUES ('Make1')
INSERT INTO Makes (Name) VALUES ('Make2')
INSERT INTO Makes (Name) VALUES ('Make3')


INSERT INTO Models (Name, MakeID) VALUES ('Make1-ModelA', (SELECT ID FROM Makes WHERE Name = 'Make1'))
INSERT INTO Models (Name, MakeID) VALUES ('Make1-ModelB', (SELECT ID FROM Makes WHERE Name = 'Make1'))
INSERT INTO Models (Name, MakeID) VALUES ('Make1-ModelC', (SELECT ID FROM Makes WHERE Name = 'Make1'))

INSERT INTO Models (Name, MakeID) VALUES ('Make2-ModelA', (SELECT ID FROM Makes WHERE Name = 'Make2'))
INSERT INTO Models (Name, MakeID) VALUES ('Make2-ModelB', (SELECT ID FROM Makes WHERE Name = 'Make2'))
INSERT INTO Models (Name, MakeID) VALUES ('Make2-ModelC', (SELECT ID FROM Makes WHERE Name = 'Make2'))


INSERT INTO Models (Name, MakeID) VALUES ('Make3-ModelA', (SELECT ID FROM Makes WHERE Name = 'Make3'))
INSERT INTO Models (Name, MakeID) VALUES ('Make3-ModelB', (SELECT ID FROM Makes WHERE Name = 'Make3'))
INSERT INTO Models (Name, MakeID) VALUES ('Make3-ModelC', (SELECT ID FROM Makes WHERE Name = 'Make3'))


INSERT INTO Features (Name) VALUES ('Feature1')
INSERT INTO Features (Name) VALUES ('Feature2')
INSERT INTO Features (Name) VALUES ('Feature3')






INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('b@b.com','max',1,1,getdate(),1)

 
INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('a@a.com','max 1',1,1,getdate(),1)
  
INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('c@c.com','max 3',1,1,getdate(),1)

 INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('d@d.com','max 4',1,1,getdate(),1)

  INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 5',1,1,getdate(),1)

  INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 6',1,1,getdate(),1)

   INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 7',1,1,getdate(),1)

    INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 8',1,1,getdate(),1)

 
    INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 9',1,1,getdate(),1)

     INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 10',1,1,getdate(),1)


INSERT INTO [Vehicles] (ContactEmail,ContactName,ContactPhone,IsRegistered,LastUpdate,ModelId)
 VALUES ('e@e.com','max 11',1,1,getdate(),1)



 insert into [VehicleFeatures] (VehicleId,FeatureId)
	values(1,1)

	 insert into [VehicleFeatures] (VehicleId,FeatureId)
	values(2,1)

insert into [VehicleFeatures] (VehicleId,FeatureId)
	values(3,1)

	insert into [VehicleFeatures] (VehicleId,FeatureId)
	values(4,2)

insert into [VehicleFeatures] (VehicleId,FeatureId)
	values(5,2)
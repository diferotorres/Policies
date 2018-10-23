CREATE TABLE TType(T_Id uniqueidentifier ROWGUIDCOL NOT NULL, T_Name varchar(50) NOT NULL, T_Percent smallint not null )

ALTER TABLE TType ADD CONSTRAINT PK_TTypeId PRIMARY KEY (T_Id)
ALTER TABLE TType ADD  CONSTRAINT [DF_TType_Id]  DEFAULT (newsequentialid()) FOR [T_Id]

CREATE TABLE TClient(C_Id uniqueidentifier ROWGUIDCOL NOT NULL, C_Name varchar(50) NOT NULL, C_Identity varchar(10) not null )
ALTER TABLE TClient ADD CONSTRAINT PK_TClientId PRIMARY KEY (C_Id)
ALTER TABLE TClient ADD  CONSTRAINT [DF_TClient_Id]  DEFAULT (newsequentialid()) FOR [C_Id]

CREATE TABLE TClientPolicy (P_ID uniqueidentifier not null, C_ID uniqueidentifier not null, PC_StartDate datetime not null)
ALTER TABLE TClientPolicy ADD CONSTRAINT PK_TClientPolicyId PRIMARY KEY (P_Id,C_ID)


ALTER TABLE TType ADD CONSTRAINT PK_TTypeId PRIMARY KEY (T_Id)
ALTER TABLE TType ADD  CONSTRAINT [DF_TType_Id]  DEFAULT (newsequentialid()) FOR [T_Id]



CREATE TABLE Tpolicy(
		P_Id uniqueidentifier ROWGUIDCOL NOT NULL,
		P_Name varchar(50) NOT NULL,
		P_Description varchar(100) NOT NULL,
		P_TypeID uniqueidentifier NOT NULL,
		P_StartDate datetime NOT NULL,
		P_Price money NOT NULL,
		P_Period_Months integer NOT NULL,
		P_RiskType smallint NOT NULL
	)

ALTER TABLE Tpolicy ADD CONSTRAINT PK_PolicyId PRIMARY KEY (P_Id) 
ALTER TABLE Tpolicy ADD  CONSTRAINT [DF_TPolicy_Id]  DEFAULT (newsequentialid()) FOR [P_Id]

--table ForlabParameters values
INSERT [ForlabParameters] ([ParmName], [ParmValue]) VALUES (N'RulesBothNegative', N'Proceed')
GO
INSERT [ForlabParameters] ([ParmName], [ParmValue]) VALUES (N'RulesBothPositive', N'Proceed')
GO
INSERT [ForlabParameters] ([ParmName], [ParmValue]) VALUES (N'RulesDiscordant', N'Proceed')
GO
INSERT [ForlabParameters] ([ParmName], [ParmValue]) VALUES (N'version', N'1.6.9')
GO
--table QuantifyMenu values
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','Total_Positive_Diagnoses','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','Total_Positive_Diagnoses_to_Receive_CD4','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','Total_Blood_Draws','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','Blood_Draws_Adult','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','Blood_Draws_Pediatric','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','PerDay_PerSite','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','PerWeek_PerSite','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','PerMonth_PerSite','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','PerQuarter_PerSite','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Consumable','PerYear_PerSite','General')
GO

INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_Chemistry_Patient_Samples_Run_On_All_Instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_Chemistry_controls_for_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_ALT_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_AST_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_CHO_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_GLC_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_CRE_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_TG_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_GGT_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_ALP_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_AMY_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_CO2_Tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_Electrolyte_Panel_tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Total_Urea_tests_on_all_instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Per_Instrument_All_Chemistry_Instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Chemistry','Per_Day_All_Chemistry_Instruments','General')
GO

INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_Syphilis_RPR_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_TB_AFB_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_Hepatitis_HBsAG_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_Hepatitis_Anti_HCV_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_TB_Culture_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_TB_DST_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_PAP_Smear_Test','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('OtherTest','Total_Genotype_Resistance_Testing_Test','General')
GO

INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('CD4','Total_CD4_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('CD4','Per_Day_All_CD4_Instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('CD4','Per_Instrument_All_CD4_Instruments','General')
GO

INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Hematology','Total_Hematology_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Hematology','Per_Day_All_Hematology_Instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('Hematology','Per_Instrument_All_Hematology_Instruments','General')
GO


INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('ViralLoad','Total_Viral_Load_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('ViralLoad','Per_Day_All_Viral_Load_Instruments','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('ViralLoad','Per_Instrument_All_Viral_Load_Instruments','General')
GO

INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Rapid_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Screenings','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Confirmatory_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Tie_Breaker_Tests','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Screenings_Plus_Confirmatory','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Confirmatory_Plus_Tie_Breaker','General')
GO
INSERT INTO QuantifyMenu (ClassOfTest,Title,TestType) VALUES ('RapidTest','Total_Screenings_Plus_Tie_Breaker','General')
GO

--table protocol values
DECLARE @protocolid int
INSERT INTO Protocol(ProtocolType,TestReapeated, SymptomDirectedAmt,Descritpion)VALUES (1,0,0,N'')
SELECT @protocolid = Scope_Identity()

INSERT ProtocolPanel (ProtocolId, PanelName, AITNewPatient, AITPreExisting, AITTestperYear, AITMonth1, AITMonth2, AITMonth3, AITMonth4, AITMonth5, AITMonth6, AITMonth7, AITMonth8, AITMonth9, AITMonth10, AITMonth11, AITMonth12, PITNewPatient, PITPreExisting, PITTestperYear, PITMonth1, PITMonth2, PITMonth3, PITMonth4, PITMonth5, PITMonth6, PITMonth7, PITMonth8, PITMonth9, PITMonth10, PITMonth11, PITMonth12, APARTNewPatient, APARTPreExisting, APARTestperYear, APARTMonth1, APARTMonth2, APARTMonth3, APARTMonth4, APARTMonth5, APARTMonth6, APARTMonth7, APARTMonth8, APARTMonth9, APARTMonth10, APARTMonth11, APARTMonth12, PPARTNewPatient, PPARTPreExisting, PPARTTestperYear, PPARTMonth1, PPARTMonth2, PPARTMonth3, PPARTMonth4, PPARTMonth5, PPARTMonth6, PPARTMonth7, PPARTMonth8, PPARTMonth9, PPARTMonth10, PPARTMonth11, PPARTMonth12) VALUES (@protocolid, N'CD4 Panel', 0, 0, 2, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1)
GO

DECLARE @chemprotocolid int
INSERT INTO Protocol(ProtocolType,TestReapeated, SymptomDirectedAmt,Descritpion)VALUES (2, 0, 0, N'')
SELECT @chemprotocolid = Scope_Identity()

INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'ALT', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'AST', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'CHO', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'GLC', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'CRE', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'TG', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'GGT', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'ALP', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'AMY', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'CO2', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'Electrolyte_Panel', NULL, 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@chemprotocolid, NULL, N'Urea', NULL, 0, 0, 0, 0)
GO

INSERT INTO Protocol(ProtocolType,TestReapeated, SymptomDirectedAmt,Descritpion)VALUES(3, 0, 0, N'')
GO
INSERT INTO Protocol(ProtocolType,TestReapeated, SymptomDirectedAmt,Descritpion)VALUES(4, 0, 0, N'')
GO

DECLARE @otherprotocolid int
INSERT INTO Protocol(ProtocolType,TestReapeated, SymptomDirectedAmt,Descritpion)VALUES(5, 0, 0, N'')
SELECT @otherprotocolid = Scope_Identity()

INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'Syphilis_RPR', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'TB_AFB', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'Hepatitis_HBsAG', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'Hepatitis_Anti_HCV', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'TB_Culture', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'TB_DST', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'PAP_Smear', 0, 0, 0, 0)
INSERT PSymptomDirectedTest (ProtocolId, TestId, ChemTestName, OtherTestName, AdultInTreatmeant, PediatricInTreatmeant, AdultPreART, PediatricPreART) VALUES (@otherprotocolid, NULL, NULL, N'Genotype_Resistance_Testing', 0, 0, 0, 0)
GO
===============
SQL语句优化
===============

.. contents::
   :local:

结果
-------------

步骤
-----------------

查出性能瓶颈
^^^^^^^^^^^^^^^^^
.. code-block:: SQL

    /*
    DROP TABLE [dbo].[__hws_t]
    GO
    CREATE TABLE [dbo].[__hws_t] ([CUS_LEVEL] varchar(1) NULL ,[PO_NO] varchar(20) NULL ,[ITM] int NULL ,[DIS_CNT_H] numeric(22,8) NULL ,[BIL_NO] varchar(20) NULL ,[CHK_MAN] varchar(12) NULL ,[REM] text NULL ,[CLS_DATE] datetime NULL ,[PAY_REM] varchar(80) NULL ,[CLS_ID] varchar(1) NULL ,[USR] varchar(12) NULL ,[SYS_DATE] datetime NULL ,[SAL_NO] varchar(12) NULL ,[EXC_RTO] numeric(22,8) NULL ,[CUR_ID] varchar(4) NULL ,[CUR_NAME] varchar(20) NULL ,[CARD_NO] varchar(20) NULL ,[CARD_ADR] varchar(200) NULL ,[AMTN_EP] numeric(22,8) NULL ,[AMTN_EP1] numeric(22,8) NULL ,[AMTN_IRP] numeric(22,8) NULL ,[CNT_MAN1] varchar(20) NULL ,[CNT_NAME] varchar(100) NULL ,[BIL_TYPE] varchar(10) NULL ,[BIL_TYPE_NAME] varchar(100) NULL ,[LOCK_MAN] varchar(12) NULL ,[PRT_SW] varchar(1) NULL ,[CK_CLS_ID] varchar(1) NULL ,[LZ_CLS_ID] varchar(1) NULL ,[POS_OS_ID] varchar(1) NULL ,[POS_OS_CLS] varchar(20) NULL ,[INV_NO] varchar(20) NULL ,[INV_DD] datetime NULL ,[AMTN_CBAC] numeric(22,8) NULL ,[PS_ID_H] varchar(2) NULL ,[OM_ID] varchar(2) NULL ,[OM_NO] varchar(20) NULL ,[BIL_REM] nvarchar(7) NULL ,[TAX_ID] nvarchar(4) NULL ,[PS_ID] nvarchar(5) NULL ,[SEND_MTH] nvarchar(2) NULL ,[PS_DD] datetime NULL ,[PS_NO] varchar(20) NULL ,[BZ_KND] varchar(40) NULL ,[BAT_NO] varchar(40) NULL ,[PRD_NO] varchar(30) NULL ,[PRD_NAME] varchar(100) NULL ,[UP_SALE] numeric(22,8) NULL ,[ME_FLAG] varchar(1) NULL ,[UNIT] varchar(1) NULL ,[WH] varchar(12) NULL ,[FREE_ID] varchar(1) NULL ,[SB_CHK] varchar(1) NULL ,[UP_QTY1] numeric(22,8) NULL ,[CK_NO] varchar(20) NULL ,[QTY_FX] numeric(22,8) NULL ,[QTY_FX_UNSH] numeric(22,8) NULL ,[AMT_DIS_CNT] numeric(22,8) NULL ,[MARK_NO] varchar(8) NULL ,[MARK_NAME] varchar(20) NULL ,[PAK_UNIT] varchar(20) NULL ,[PAK_EXC] numeric(22,8) NULL ,[PAK_NW] numeric(24,8) NULL ,[PAK_WEIGHT_UNIT] varchar(8) NULL ,[PAK_GW] numeric(24,8) NULL ,[PAK_MEAST] numeric(22,8) NULL ,[PAK_MEAST_UNIT] varchar(8) NULL ,[TAX] numeric(38,7) NULL ,[CUS_OS_NO] varchar(30) NULL ,[UP] numeric(22,8) NULL ,[DIS_CNT] numeric(22,8) NULL ,[VALID_DD] datetime NULL ,[QTY_RTN] numeric(22,8) NULL ,[QTY_OI] numeric(22,8) NULL ,[TAX_RTO] numeric(22,8) NULL ,[EST_DD] datetime NULL ,[PRD_MARK] varchar(40) NULL ,[OS_NO] varchar(25) NULL ,[SH_NO_CUS] varchar(20) NULL ,[OS_ID] varchar(2) NULL ,[SUP_PRD_NO] varchar(40) NULL ,[SUP_PRD_NAME] varchar(100) NULL ,[NB_BOX_NO] varchar(255) NULL ,[AMT_FP] numeric(24,8) NULL ,[UP_DIS_CNT] numeric(38,9) NULL ,[GROUP_CY_HDL] nvarchar(5) NULL ,[GROUP_CY_NO] varchar(20) NULL ,[GROUP_CY_ID] varchar(2) NULL ,[GROUP_CY_ITM] int NULL ,[GROUP_DX_PCID] varchar(2) NULL ,[Expr1] varchar(2) NULL ,[GROUP_DX_PCNO] varchar(20) NULL ,[QTY_GROUP_DXCY] numeric(22,8) NULL ,[PRD_IMAGE] nvarchar(5) NULL ,[CST_STD] numeric(24,8) NULL ,[AMTN_NET_FP] numeric(24,8) NULL ,[TAX_FP] numeric(24,8) NULL ,[QTY_FP] numeric(24,8) NULL ,[QTY] numeric(24,8) NULL ,[HZ_UP_TYDJ] numeric(22,8) NULL ,[HZ_AMTN_TYDJ] numeric(38,7) NULL ,[QTY1] numeric(24,8) NULL ,[AMTN_NET] numeric(38,7) NULL ,[AMT] numeric(38,7) NULL ,[AMTN_SALE] numeric(24,8) NULL ,[AMT_ZDZK] numeric(24,8) NULL ,[AMTN_NET_ZDZK] numeric(24,8) NULL ,[TAX_ZDZK] numeric(24,8) NULL ,[AMTN_NET1] numeric(38,6) NULL ,[AMT1] numeric(38,7) NULL ,[TB_NOSENCOD] varchar(20) NULL ,[CSTN_SAL] numeric(24,8) NULL ,[CUS_NAME] varchar(100) NULL ,[CUS_NO] varchar(12) NULL ,[CUS_ARE] varchar(20) NULL ,[CST_STD_UNIT] numeric(38,16) NULL ,[DEP_NAME] varchar(100) NULL ,[DEP] varchar(8) NULL ,[WH_NAME] varchar(100) NULL ,[IDX_NO] varchar(20) NULL ,[IDX_NAME] varchar(50) NULL ,[CAS_NAME] varchar(80) NULL ,[CAS_NO] varchar(20) NULL ,[TASK_ID] int NULL ,[SAL_NAME] varchar(50) NULL ,[SPC] text NULL ,[UPR] numeric(22,8) NULL ,[CHK_MAN_NAME] varchar(100) NULL ,[USR_NAME] varchar(100) NULL ,[LOCK_MAN_NAME] varchar(100) NULL ,[MODIFY_MAN] varchar(12) NULL ,[MODIFY_MAN_NAME] varchar(100) NULL ,[ARE_NAME] varchar(100) NULL ,[BAT_NAME] varchar(80) NULL ,[CARD_NAME] varchar(100) NULL ,[CUS_FH_NAME] varchar(100) NULL ,[CUS_FH] varchar(12) NULL ,[CUS_FX_NAME] varchar(100) NULL ,[CUS_FX] varchar(12) NULL ,[DEP_FH_NAME] varchar(100) NULL ,[DEP_FH] varchar(8) NULL ,[MTN_REM] text NULL ,[SPC_NO] varchar(12) NULL ,[SPC_NAME] varchar(100) NULL ,[QTY_CFM] numeric(22,8) NULL ,[QTY_LOST] numeric(22,8) NULL ,[TASK_NAME] varchar(255) NULL ,[PRM_NO] varchar(20) NULL ,[REM_T] varchar(200) NULL ,[REM_XP] varchar(200) NULL ,[SAL_NO1] varchar(12) NULL ,[SAL_NAME1] varchar(50) NULL ,[MODIFY_DD] datetime NULL ,[QTY_BAR] int NULL ,[CUS_NO_KD] varchar(12) NULL ,[CUS_NAME_KD] varchar(100) NULL ,[CON_MAN] varchar(40) NULL ,[FH_NO] varchar(20) NULL ,[ADR] varchar(200) NULL ,[ZIP] varchar(10) NULL ,[TEL_NO] varchar(40) NULL ,[CELL_NO] varchar(40) NULL ,[RCV_CHK] varchar(1) NULL ,[SHOP_NO] varchar(20) NULL ,[TB_NO] varchar(20) NULL ,[TB_STATUS] varchar(100) NULL ,[AMTN_TB] numeric(22,8) NULL ,[EVAL_TYPE] varchar(1) NULL ,[EVAL_REM] text NULL ,[EVAL1_TYPE] varchar(1) NULL ,[EVAL1_REM] text NULL ,[TB_REM] text NULL ,[ACT_DSC] text NULL ,[TYPE_ID] varchar(12) NULL ,[CUS_NO_POS] varchar(50) NULL ,[INST_TEAM] varchar(50) NULL ,[AMTN_DS] numeric(22,8) NULL ,[DPJ_HJ_MF_PSS_Z] numeric(22,8) NULL ,[CUSNM_MF_PSS_Z] varchar(50) NULL ,[CUSNO_MF_PSS_Z] varchar(10) NULL ,[kddh_MF_PSS_Z] varchar(100) NULL ,[SAPS_NO_MF_PSS_Z] varchar(20) NULL ,[YM_NO_MF_PSS_Z] varchar(20) NULL ,[amtn_dpj_TF_PSS_Z] numeric(22,8) NULL ,[UP_DPJ_TF_PSS_Z] numeric(22,8) NULL ,[HS_AMTN1_TF_PSS_Z] numeric(22,8) NULL ,[SCDD_TF_PSS_Z] varchar(30) NULL )
    GO

    SUP_PRD_MARK


    */
    insert __hws_t
    (AMTN_DS,AMTN_EP,AMTN_EP1,AMTN_IRP,BIL_NO,BIL_TYPE,CARD_NO,CAS_NO,CHK_MAN,CK_CLS_ID,CLS_DATE,CLS_ID,CNT_MAN1,CUR_ID,CUS_FH,CUS_FX,CUS_NO_POS,DEP,DEP_FH,DIS_CNT_H,EXC_RTO,INST_TEAM,INV_NO,LOCK_MAN,LZ_CLS_ID,MODIFY_DD,MODIFY_MAN,PAY_REM,PO_NO,POS_OS_CLS,POS_OS_ID,PRT_SW,REM,SAL_NO,SB_CHK,SYS_DATE,TASK_ID,USR,AMT_DIS_CNT,BAT_NO,CK_NO,CUS_OS_NO,DIS_CNT,EST_DD,FREE_ID,GROUP_CY_ID,GROUP_CY_ITM,GROUP_CY_NO,GROUP_DX_PCID,Expr1,GROUP_DX_PCNO,ITM,ME_FLAG,MTN_REM,NB_BOX_NO,OM_ID,OM_NO,OS_ID,OS_NO,PAK_EXC,PAK_MEAST,PAK_MEAST_UNIT,PAK_UNIT,PAK_WEIGHT_UNIT,PRD_MARK,PRD_NAME,PRD_NO,PRM_NO,PS_DD,PS_ID_H,PS_NO,QTY_CFM,QTY_FX,QTY_FX_UNSH,QTY_GROUP_DXCY,QTY_LOST,QTY_OI,QTY_RTN,REM_T,REM_XP,SH_NO_CUS,SUP_PRD_NO,TAX_RTO,UNIT,UP,UP_QTY1,VALID_DD,WH,SPC,UPR,AMTN_TB,EVAL_REM,EVAL_TYPE,EVAL1_REM,EVAL1_TYPE,SHOP_NO,TB_NO,TB_REM,TB_STATUS)
    select top 1 A.AMTN_DS,A.AMTN_EP,A.AMTN_EP1,A.AMTN_IRP,A.BIL_NO,A.BIL_TYPE,A.CARD_NO,A.CAS_NO,A.CHK_MAN,A.CK_CLS_ID,A.CLS_DATE,A.CLS_ID,A.CNT_MAN1,A.CUR_ID,A.CUS_FH,A.CUS_FX,A.CUS_NO_POS,A.DEP,A.DEP_FH,A.DIS_CNT,A.EXC_RTO,A.INST_TEAM,A.INV_NO,A.LOCK_MAN,A.LZ_CLS_ID,A.MODIFY_DD,A.MODIFY_MAN,A.PAY_REM,A.PO_NO,A.POS_OS_CLS,A.POS_OS_ID,A.PRT_SW,A.REM,A.SAL_NO,A.SB_CHK,A.SYS_DATE,A.TASK_ID,A.USR,B.AMT_DIS_CNT,B.BAT_NO,B.CK_NO,B.CUS_OS_NO,B.DIS_CNT,B.EST_DD,B.FREE_ID,B.GROUP_CY_ID,B.GROUP_CY_ITM,B.GROUP_CY_NO,B.GROUP_DX_PCID,B.GROUP_DX_PCID,B.GROUP_DX_PCNO,B.ITM,B.ME_FLAG,B.MTN_REM,B.NB_BOX_NO,B.OM_ID,B.OM_NO,B.OS_ID,B.OS_NO,B.PAK_EXC,B.PAK_MEAST,B.PAK_MEAST_UNIT,B.PAK_UNIT,B.PAK_WEIGHT_UNIT,B.PRD_MARK,B.PRD_NAME,B.PRD_NO,B.PRM_NO,B.PS_DD,B.PS_ID,B.PS_NO,B.QTY_CFM,B.QTY_FX,B.QTY_FX_UNSH,B.QTY_GROUP_DXCY,B.QTY_LOST,B.QTY_OI,B.QTY_RTN,B.REM,B.REM_XP,B.SH_NO_CUS,B.SUP_PRD_NO,B.TAX_RTO,B.UNIT,B.UP,B.UP_QTY1,B.VALID_DD,B.WH,P.SPC,P.UPR,TB_1.AMTN_TB,TB_1.EVAL_REM,TB_1.EVAL_TYPE,TB_1.EVAL1_REM,TB_1.EVAL1_TYPE,TB_1.SHOP_NO,TB_1.TB_NO,TB_1.TB_REM,TB_1.TB_STATUS from mf_pss A WITH (NOLOCK)
     INNER JOIN TF_PSS AS B ON B.PS_ID = A.PS_ID AND B.PS_NO = A.PS_NO LEFT OUTER JOIN
    PRDT AS P ON P.PRD_NO = B.PRD_NO LEFT OUTER JOIN
        (SELECT   TB.SHOP_NO, TB.TB_NO, TB.TB_STATUS, TB.AMTN_TB, TB.EVAL_TYPE, TB.EVAL_REM, TB.EVAL1_TYPE,TB.EVAL1_REM, TB.TB_REM, TB.TYPE_ID, TB.OS_ID, TB.OS_NO
         FROM      TF_POS_TB AS TB 
         WHERE   (TB.OS_ID = 'SO') AND (ISNULL(TB.TYPE_ID, '') IN ('', 'TB', 'ERP', 'JD', '4'))) 
    AS TB_1 ON TB_1.OS_ID = B.OS_ID AND TB_1.OS_NO = B.OS_NO
    WHERE   (A.PS_ID IN ('SA', 'SB', 'SD')) AND (A.PS_DD >= '2016-05-01 00:00:00') AND (A.PS_DD <= '2016-05-01 23:59:59') AND 
                    (A.PS_DD BETWEEN '2016-05-01 00:00:00' AND '2016-05-01 23:59:59') AND (ISNULL(TB_1.TYPE_ID, '') IN ('', 'TB', 
                    'ERP', 'JD', '4')) AND (A.ISSVS = 'F' OR
                    A.ISSVS IS NULL) AND (P.KND IN ('1', '2', '3', '4', '5', '6', '7', 'A', 'B', 'C')) AND (P.KND <> 'B') OR
                    (A.PS_ID IN ('SA', 'SB', 'SD')) AND (A.PS_DD >= '2016-05-01 00:00:00') AND (A.PS_DD <= '2016-05-01 23:59:59') AND 
                    (A.PS_DD BETWEEN '2016-05-01 00:00:00' AND '2016-05-01 23:59:59') AND (ISNULL(TB_1.TYPE_ID, '') IN
                        (SELECT   TYPE_ID
                         FROM      SCTYPE_SET)) AND (A.ISSVS = 'F' OR
                    A.ISSVS IS NULL) AND (P.KND IN ('1', '2', '3', '4', '5', '6', '7', 'A', 'B', 'C')) AND (P.KND <> 'B') OR
                    (A.PS_ID IN ('SA', 'SB', 'SD')) AND (A.PS_DD >= '2016-05-01 00:00:00') AND (A.PS_DD <= '2016-05-01 23:59:59') AND 
                    (A.PS_DD BETWEEN '2016-05-01 00:00:00' AND '2016-05-01 23:59:59') AND (ISNULL(TB_1.TYPE_ID, '') IN ('', 'TB', 
                    'ERP', 'JD', '4')) AND (A.ISSVS = 'F' OR
                    A.ISSVS IS NULL) AND (P.KND IN ('1', '2', '3', '4', '5', '6', '7', 'A', 'B', 'C')) AND (P.PRD_NO NOT IN ('SK01')) OR
                    (A.PS_ID IN ('SA', 'SB', 'SD')) AND (A.PS_DD >= '2016-05-01 00:00:00') AND (A.PS_DD <= '2016-05-01 23:59:59') AND 
                    (A.PS_DD BETWEEN '2016-05-01 00:00:00' AND '2016-05-01 23:59:59') AND (ISNULL(TB_1.TYPE_ID, '') IN
                        (SELECT   TYPE_ID
                         FROM      SCTYPE_SET AS SCTYPE_SET_1)) AND (A.ISSVS = 'F' OR
                    A.ISSVS IS NULL) AND (P.KND IN ('1', '2', '3', '4', '5', '6', '7', 'A', 'B', 'C')) AND (P.PRD_NO NOT IN ('SK01'))

                    /*
    WHERE   (A.PS_ID IN ('SA', 'SB', 'SD')) AND 
            (A.PS_DD BETWEEN '2016-05-01 00:00:00' AND '2016-05-01 23:59:59')  AND (A.ISSVS = 'F' OR
            A.ISSVS IS NULL) 
            AND (P.KND IN ('1', '2', '3', '4', '5', '6', '7', 'A', 'B', 'C'))                
            AND (((ISNULL(TB_1.TYPE_ID, '') IN ('', 'TB', 'ERP', 'JD', '4'))  AND ((P.KND <> 'B')  OR P.PRD_NO NOT IN ('SK01'))) 
                OR
                ((ISNULL(TB_1.TYPE_ID, '') IN (SELECT TYPE_ID FROM SCTYPE_SET)) AND ((P.KND <> 'B')  OR P.PRD_NO NOT IN ('SK01'))))
                    */

    UPDATE __hws_t
    SET 
    CHK_MAN_NAME=PD1.NAME,
    USR_NAME=PD2.NAME,
    LOCK_MAN_NAME=PD3.NAME,
    MODIFY_MAN_NAME=PD4.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    DB_PSWD AS PD1 ON PD1.USR = A.CHK_MAN AND PD1.COMPNO = 'HZ' LEFT OUTER JOIN
    DB_PSWD AS PD2 ON PD2.USR = A.USR AND PD2.COMPNO = 'HZ' LEFT OUTER JOIN
    DB_PSWD AS PD3 ON PD3.USR = A.LOCK_MAN AND PD3.COMPNO = 'HZ' LEFT OUTER JOIN
    DB_PSWD AS PD4 ON PD4.USR = A.MODIFY_MAN AND PD4.COMPNO = 'HZ' 


    UPDATE __hws_t
    SET 
    BIL_TYPE_NAME=L.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    BIL_SPC AS L ON L.BIL_ID = 'SA' AND L.SPC_NO = A.BIL_TYPE 


    UPDATE __hws_t
    SET 
    SAL_NAME=S.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    SALM AS S ON S.SAL_NO = A.SAL_NO 


    UPDATE __hws_t
    SET 
    DEP_NAME=D.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    DEPT AS D ON D.DEP = A.DEP 


    UPDATE __hws_t
    SET 
    CUSNM_MF_PSS_Z=MF_PSS_Z.CUSNM,
    CUSNO_MF_PSS_Z=MF_PSS_Z.CUSNO,
    DPJ_HJ_MF_PSS_Z=MF_PSS_Z.DPJ_HJ,
    kddh_MF_PSS_Z=MF_PSS_Z.KDDH,
    SAPS_NO_MF_PSS_Z=MF_PSS_Z.SAPS_NO,
    YM_NO_MF_PSS_Z=MF_PSS_Z.YM_NO
    FROM  __hws_t as A LEFT OUTER JOIN
    MF_PSS_Z ON A.PS_ID = MF_PSS_Z.PS_ID AND A.PS_NO = MF_PSS_Z.PS_NO


    UPDATE __hws_t
    SET 
    ADR=KD.ADR,
    CELL_NO=KD.CELL_NO,
    CON_MAN=KD.CON_MAN,
    CUS_NO_KD=KD.CUS_NO_KD,
    FH_NO=KD.FH_NO,
    RCV_CHK=KD.RCV_CHK,
    TEL_NO=KD.TEL_NO,
    ZIP=KD.ZIP
    FROM  __hws_t as A LEFT OUTER JOIN
    TF_PSS_RCV AS KD ON KD.PS_NO = A.PS_NO AND KD.PS_ID = A.PS_ID 

    UPDATE __hws_t
    SET 
    CARD_ADR=K.ADR,
    CARD_NAME=K.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    POSCARD AS K ON K.CARD_NO = A.CARD_NO


    UPDATE __hws_t
    SET 
    DEP_FH_NAME=DFH.NAME,
    CUS_FH_NAME=CFH.NAME,
    CUS_FX_NAME=CFX.NAME
    FROM  __hws_t as A LEFT OUTER JOIN
    CUST AS CFH ON CFH.CUS_NO = A.CUS_FH LEFT OUTER JOIN
    CUST AS CFX ON CFX.CUS_NO = A.CUS_FX LEFT OUTER JOIN
    DEPT AS DFH ON DFH.DEP = A.DEP_FH 


    ----UPDATE __hws_t
    ----SET 
    ----SPC_NAME=BS.NAME,
    ----SPC_NO=BS.SPC_NO,
    ----CUS_ARE=C.CUS_ARE,
    ----CUS_LEVEL=C.CUS_LEVEL,
    ----CUS_NO=C.CUS_NO,
    ----CUS_NAME=C.NAME,
    ----SUP_PRD_NAME=SUP.SUP_PRD_NAME,
    ----ARE_NAME=X.NAME
    ----FROM  __hws_t as A LEFT OUTER JOIN
    ----CUST AS C ON C.CUS_NO = A.CUS_NO LEFT OUTER JOIN
    ----BIL_SPC AS BS ON BS.BIL_ID = 'KH' AND BS.SPC_ID = 'HY' AND BS.SPC_NO = C.BIZ_DSC LEFT OUTER JOIN
    ----AREA AS X ON X.AREA_NO = C.CUS_ARE LEFT OUTER JOIN
    ----PRDT_CUS1 AS SUP ON SUP.PRD_NO = A.PRD_NO AND SUP.CUS_NO = A.CUS_NO AND SUP.AREA_NO = X.AREA_NO AND SUP.PRD_MARK = A.PRD_MARK 
    ----    AND SUP.SUP_PRD_MARK = A.SUP_PRD_MARK 



    UPDATE __hws_t
    SET 
    IDX_NO=I.IDX_NO,
    IDX_NAME=I.NAME,
    MARK_NO=MK.MARK_NO,
    MARK_NAME=MK.NAME,
    SPC=P.SPC,
    UPR=P.UPR
    FROM  __hws_t as A LEFT OUTER JOIN
    PRDT AS P ON P.PRD_NO = A.PRD_NO LEFT OUTER JOIN
    INDX AS I ON I.IDX_NO = P.IDX1 LEFT OUTER JOIN
    MARK AS MK ON MK.MARK_NO = P.MRK 

    --性能问题
    UPDATE __hws_t
    SET 
    WH_NAME=M.NAME,
    BAT_NAME=N.NAME,
    amtn_dpj_TF_PSS_Z=TF_PSS_Z.AMTN_DPJ,
    HS_AMTN1_TF_PSS_Z=TF_PSS_Z.HS_AMTN1,
    SCDD_TF_PSS_Z=TF_PSS_Z.SCDD,
    UP_DPJ_TF_PSS_Z=TF_PSS_Z.UP_DPJ
    FROM  __hws_t as A LEFT OUTER JOIN
    TF_PSS_Z ON a.PS_ID = TF_PSS_Z.PS_ID AND A.PS_NO = TF_PSS_Z.PS_NO AND A.ITM = TF_PSS_Z.ITM LEFT OUTER JOIN
    MY_WH AS M ON M.WH = A.WH LEFT OUTER JOIN
    BAT_NO AS N ON N.BAT_NO = A.BAT_NO


    --UPDATE __hws_t
    --SET 
    --AMTN_TB=TB_1.AMTN_TB,
    --EVAL_REM=TB_1.EVAL_REM,
    --EVAL_TYPE=TB_1.EVAL_TYPE,
    --EVAL1_REM=TB_1.EVAL1_REM,
    --EVAL1_TYPE=TB_1.EVAL1_TYPE,
    --SHOP_NO=TB_1.SHOP_NO,
    --TB_NO=TB_1.TB_NO,
    --TB_REM=TB_1.TB_REM,
    --TB_STATUS=TB_1.TB_STATUS
    --FROM  __hws_t as A LEFT OUTER JOIN
    --    (SELECT   TB.SHOP_NO, TB.TB_NO, TB.TB_STATUS, TB.AMTN_TB, TB.EVAL_TYPE, TB.EVAL_REM, TB.EVAL1_TYPE, 
    --                     TB.EVAL1_REM, TB.TB_REM, TB.TYPE_ID, TB.OS_ID, TB.OS_NO
    --     FROM      TF_POS_TB AS TB INNER JOIN
    --                     MF_POS AS MF ON TB.OS_ID = MF.OS_ID AND TB.OS_NO = MF.OS_NO
    --     WHERE   (TB.OS_ID = 'SO') AND (ISNULL(TB.TYPE_ID, '') IN ('', 'TB', 'ERP', 'JD', '4'))) AS TB_1 ON TB_1.OS_ID = B.OS_ID AND TB_1.OS_NO = B.OS_NO


    ----UPDATE __hws_t
    ----SET 
    ----BZ_KND=BZ.NAME,
    ----SAL_NAME1=S1.NAME,
    ----SAL_NO1=S1.SAL_NO,
    ----TASK_NAME=TK.NAME,
    ----ACT_DSC=UPPOS_ACT.NAME
    ----FROM  __hws_t as A LEFT OUTER JOIN
    ----BZ_KND AS BZ ON A.BZ_KND = BZ.BZ_KND LEFT OUTER JOIN
    ----SALM AS S1 ON S1.SAL_NO = A.SAL_NO LEFT OUTER JOIN
    ----UPPOS_ACT ON UPPOS_ACT.DEF_NO = A.DEF_NO AND ISNULL(A.FREE_ID, '') = 'T' LEFT OUTER JOIN
    ----TASK AS TK ON TK.TASK_NO = A.PRM_NO


* 占本批91%的资源开销

.. code-block:: SQL

    UPDATE __hws_t
    SET 
    WH_NAME=M.NAME,
    BAT_NAME=N.NAME,
    amtn_dpj_TF_PSS_Z=TF_PSS_Z.AMTN_DPJ,
    HS_AMTN1_TF_PSS_Z=TF_PSS_Z.HS_AMTN1,
    SCDD_TF_PSS_Z=TF_PSS_Z.SCDD,
    UP_DPJ_TF_PSS_Z=TF_PSS_Z.UP_DPJ
    FROM  __hws_t as A LEFT OUTER JOIN
    TF_PSS_Z ON a.PS_ID = TF_PSS_Z.PS_ID AND A.PS_NO = TF_PSS_Z.PS_NO AND A.ITM = TF_PSS_Z.ITM LEFT OUTER JOIN
    MY_WH AS M ON M.WH = A.WH LEFT OUTER JOIN
    BAT_NO AS N ON N.BAT_NO = A.BAT_NO   



重建索引前
^^^^^^^^^^^^^

* DBCC SHOWCONTIG

.. code-block:: SQL

    DBCC SHOWCONTIG('tf_pss_z')

.. sidebar:: 关注点   

    * 扫描密度行，最佳计数和实际计数的比例已经严重失调
    * 逻辑扫描碎片占了非常大的比重
    * 每页平均可用字节数非常大时

::

    - 扫描页数................................: 54159
    - 扫描区数..............................: 6839
    - 区切换次数..............................: 43634
    - 每个区的平均页数........................: 7.9
    - 扫描密度 [最佳计数:实际计数].......: 15.52% [6770:43635]
    - 逻辑扫描碎片 ..................: 82.22%
    - 区扫描碎片 ..................: 82.06%
    - 每页的平均可用字节数.....................: 1559.8
    - 平均页密度(满).....................: 80.73%



优化流程总结
---------------

    #. 美化
    #. 拆分
        #. 借助图形化编辑器提取主语句
        #. 借助Excel处理各表与字段
    #. 比较
    #. 优化
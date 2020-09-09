```sql
-- === 列出DB所有Table名稱 & 單一Table Schema ===
-- 使用方法: 1. 修改資料庫名稱；2. 修改資料表名稱

--使用資料庫
use 資料庫名稱

--所有資料庫清單
select name from master.dbo.sysdatabases

--資料庫 View 列表
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'

--目前使用者在目前資料庫中可以存取的資料表
SELECT name '資料表名稱', (SELECT value FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', name, NULL, NULL)) '中文名稱' FROM sys.tables order by name

--資料表詳情
SELECT * FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', '資料表名稱', NULL, NULL)

--DB Schema
SELECT tab.name '資料表名稱',
       col.colid '識別碼', 
       col.name '欄位名稱', 
       (SELECT VALUE 
        FROM   Fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', 
       tab.name, 
       'column',
       col.name)) '欄位中文名稱',
       typ.name '型態', 
       col.prec '有效位數', 
       col.scale '資料範圍', 
       col.length '長度', 
       com.TEXT '預設值',         
       CASE 
         WHEN 
         (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '資料表名稱' and Column_Name = col.name and CONSTRAINT_NAME like 'PK%') = 1 THEN 'PK' 
         WHEN 
         (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '資料表名稱' and Column_Name = col.name and CONSTRAINT_NAME like 'FK%') = 1 THEN 'FK' 
         ELSE '' 
       END '鍵值',
       CASE 
         WHEN col.isnullable = 1 THEN 'Y' 
         ELSE 'N' 
       END '空值',
       CASE 
         WHEN col.status & 0X80 = 0X80 THEN 'Y' 
         ELSE 'N' 
       END 'Identity' 
FROM   sysobjects tab, 
       syscolumns col 
       LEFT OUTER JOIN syscomments com 
                       INNER JOIN sysobjects obj 
                         ON com.id = obj.id 
         ON col.cdefault = com.id 
            AND com.colid = 1, 
       systypes typ 
WHERE  tab.id = col.id 
       AND tab.xtype = 'U' 
       AND col.xusertype = typ.xusertype
       and tab.name = '資料表名稱'



--新增或修改資料表說明
IF not exists(SELECT * FROM fn_listextendedproperty (NULL, 'user', 'dbo', 'table', '資料表名稱', NULL, NULL))  
BEGIN
  exec sp_addextendedproperty 'MS_Description', '', 'user', 'dbo', 'table', '資料表名稱'
END
ELSE
BEGIN
  exec sp_updateextendedproperty 'MS_Description', '', 'user', 'dbo', 'table', '資料表名稱'
END

--新增或修改欄位說明
IF not exists(SELECT * FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', 'news', 'column', 'date')) 
BEGIN
  exec sp_addextendedproperty 'MS_Description', 'A', 'user', 'dbo', 'table', 'news', 'column', 'date'
END
ELSE
BEGIN
  exec sp_updateextendedproperty 'MS_Description', 'B', 'user', 'dbo', 'table', 'news', 'column', 'date'
END


--撈出資料表PK
Select Column_Name '主鍵欄位' FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '資料表名稱' and CONSTRAINT_NAME like 'PK%'

SELECT Col.Column_Name '主鍵欄位' from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, 
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col 
WHERE 
    Col.Constraint_Name = Tab.Constraint_Name
    AND Col.Table_Name = Tab.Table_Name
    AND Constraint_Type = 'PRIMARY KEY'
    AND Col.Table_Name = '資料表名稱'


--撈出資料表FK
Select Column_Name '外鍵欄位' FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '資料表名稱' and CONSTRAINT_NAME like 'FK%'

-- === 其他常用系統語法 ===

--資料庫裏的所有欄位
--SELECT * FROM Information_Schema.COLUMNS 

--目前資料庫中的索引鍵。
--SELECT * FROM Information_Schema.KEY_COLUMN_USAGE 

--目前資料庫中的資料表條件約束
--SELECT * FROM Information_Schema.TABLE_CONSTRAINTS 

--目前資料庫中的外部條件約束
--SELECT * FROM Information_Schema.REFERENTIAL_CONSTRAINTS
```

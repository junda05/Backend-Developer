-- 1. Seleccionar todos los usuarios
SELECT * FROM Users;

-- 2. Seleccionar un usuario por ID
SELECT * FROM Users WHERE Id = 1;

-- 3. Seleccionar columnas específicas
SELECT Id, Name, Email FROM Users;

-- 4. Filtrar por nombre
SELECT * FROM Users WHERE Name = 'Miguel Torres';

-- 5. Filtrar por edad
SELECT * FROM Users WHERE Age >= 18;

-- 6. Buscar por email
SELECT * FROM Users WHERE Email = 'miguel.torres@gmail.com';

-- 7. Buscar con LIKE (coincidencia parcial)
SELECT * FROM Users WHERE Name LIKE '%Juan%';
SELECT * FROM Users WHERE Email LIKE '%@gmail.com';

-- 8. Ordenar resultados
SELECT * FROM Users ORDER BY Name ASC;
SELECT * FROM Users ORDER BY Age DESC;
SELECT * FROM Users ORDER BY CreatedAt DESC;

-- 9. Limitar resultados (Top N)
SELECT TOP 5 * FROM Users;
SELECT TOP 10 * FROM Users ORDER BY CreatedAt DESC;

-- 10. Contar usuarios
SELECT COUNT(*) FROM Users;
SELECT COUNT(*) AS TotalUsuarios FROM Users;


-- ============================================================================
-- CONSULTAS AVANZADAS
-- ============================================================================

-- 1. Filtros múltiples con AND/OR
SELECT * FROM Users 
WHERE Age >= 25 AND Age <= 30;

SELECT * FROM Users 
WHERE Name LIKE '%Ana%' OR Name LIKE '%Juan%';

SELECT * FROM Users 
WHERE Age > 25 AND Email LIKE '%@gmail.com';

-- 2. Filtros con IN
SELECT * FROM Users 
WHERE Age IN (18, 25, 30, 35);

SELECT * FROM Users 
WHERE Name IN ('Juan', 'Ana', 'Pedro');

-- 3. Filtros con BETWEEN
SELECT * FROM Users 
WHERE Age BETWEEN 20 AND 40;

SELECT * FROM Users 
WHERE CreatedAt BETWEEN '2024-01-01' AND '2024-12-31';

-- 4. Consultas con NULL
SELECT * FROM Users WHERE Email IS NULL;
SELECT * FROM Users WHERE Email IS NOT NULL;

-- 5. Agregaciones (COUNT, AVG, MIN, MAX, SUM)
-- Edad promedio
SELECT AVG(Age) AS EdadPromedio FROM Users;

-- Edad mínima y máxima
SELECT MIN(Age) AS EdadMinima, MAX(Age) AS EdadMaxima FROM Users;

-- Estadísticas completas
SELECT 
    COUNT(*) AS Total, 
    AVG(Age) AS Promedio,
    MIN(Age) AS Minima,
    MAX(Age) AS Maxima
FROM Users;

-- 6. GROUP BY (Agrupar resultados)
-- Usuarios agrupados por edad
SELECT Age, COUNT(*) AS Cantidad 
FROM Users 
GROUP BY Age 
ORDER BY Age;

-- Usuarios por año de creación
SELECT YEAR(CreatedAt) AS Año, COUNT(*) AS Total 
FROM Users 
GROUP BY YEAR(CreatedAt);

-- Filtrar grupos con HAVING
SELECT Age, COUNT(*) AS Cantidad 
FROM Users 
GROUP BY Age 
HAVING COUNT(*) > 1;

-- 7. DISTINCT (Valores únicos)
SELECT DISTINCT Age FROM Users ORDER BY Age;
SELECT DISTINCT YEAR(CreatedAt) AS Año FROM Users;

-- 8. Subconsultas
-- Usuarios mayores al promedio
SELECT * FROM Users 
WHERE Age > (SELECT AVG(Age) FROM Users);

-- Usuarios con la edad máxima
SELECT * FROM Users 
WHERE Age = (SELECT MAX(Age) FROM Users);

-- Usuarios con la edad mínima
SELECT * FROM Users 
WHERE Age = (SELECT MIN(Age) FROM Users);

-- 9. CASE (Condicionales)
SELECT 
    Id,
    Name,
    Age,
    CASE 
        WHEN Age < 18 THEN 'Menor de edad'
        WHEN Age BETWEEN 18 AND 65 THEN 'Adulto'
        ELSE 'Adulto mayor'
    END AS Categoria
FROM Users;

SELECT 
    Name,
    Email,
    CASE 
        WHEN Email LIKE '%@gmail.com' THEN 'Gmail'
        WHEN Email LIKE '%@hotmail.com' THEN 'Hotmail'
        WHEN Email LIKE '%@outlook.com' THEN 'Outlook'
        ELSE 'Otro'
    END AS TipoEmail
FROM Users;

-- 10. Funciones de fecha
-- Usuarios creados hoy
SELECT * FROM Users 
WHERE CAST(CreatedAt AS DATE) = CAST(GETDATE() AS DATE);

-- Usuarios creados en los últimos 7 días
SELECT * FROM Users 
WHERE CreatedAt >= DATEADD(DAY, -7, GETDATE());

-- Usuarios creados en los últimos 30 días
SELECT * FROM Users 
WHERE CreatedAt >= DATEADD(DAY, -30, GETDATE());

-- Usuarios creados este mes
SELECT * FROM Users 
WHERE YEAR(CreatedAt) = YEAR(GETDATE()) 
  AND MONTH(CreatedAt) = MONTH(GETDATE());

-- Usuarios creados este año
SELECT * FROM Users 
WHERE YEAR(CreatedAt) = YEAR(GETDATE());

-- Formatear fechas
SELECT 
    Name,
    FORMAT(CreatedAt, 'dd/MM/yyyy') AS FechaCreacion,
    FORMAT(CreatedAt, 'dd/MM/yyyy HH:mm:ss') AS FechaHoraCreacion,
    DATEDIFF(DAY, CreatedAt, GETDATE()) AS DiasDesdeCreacion
FROM Users;

-- 11. Paginación (OFFSET/FETCH)
-- Página 1 (primeros 10)
SELECT * FROM Users 
ORDER BY Id 
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;

-- Página 2 (siguientes 10)
SELECT * FROM Users 
ORDER BY Id 
OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;

-- Página 3 (siguientes 10)
SELECT * FROM Users 
ORDER BY Id 
OFFSET 20 ROWS FETCH NEXT 10 ROWS ONLY;

-- 12. Búsqueda de texto completo
-- Buscar en múltiples campos
SELECT * FROM Users 
WHERE Name LIKE '%search%' 
   OR Email LIKE '%search%';

-- Búsqueda insensible a mayúsculas
SELECT * FROM Users 
WHERE LOWER(Email) LIKE LOWER('%@GMAIL.COM%');

-- Búsqueda por dominio de email
SELECT * FROM Users 
WHERE Email LIKE '%@' + 'gmail.com';

-- 13. Actualización de datos
-- Actualizar un usuario específico
UPDATE Users 
SET Name = 'Nuevo Nombre', UpdatedAt = GETDATE() 
WHERE Id = 1;

-- Actualizar email de un usuario
UPDATE Users 
SET Email = 'nuevo@example.com', UpdatedAt = GETDATE() 
WHERE Id = 1;

-- Actualizar edad y fecha de actualización
UPDATE Users 
SET Age = 30, UpdatedAt = GETDATE() 
WHERE Id = 1;

-- Actualizar múltiples usuarios
UPDATE Users 
SET Age = Age + 1, UpdatedAt = GETDATE() 
WHERE Age < 18;

-- 14. Eliminación de datos
-- Eliminar un usuario específico
DELETE FROM Users WHERE Id = 1;

-- Eliminar usuarios con condición
DELETE FROM Users WHERE Age < 18;

-- Eliminar usuarios inactivos (ejemplo)
DELETE FROM Users 
WHERE DATEDIFF(DAY, UpdatedAt, GETDATE()) > 365;

-- 15. Inserción de datos
-- Insertar un usuario
INSERT INTO Users (Name, Email, Age, CreatedAt, UpdatedAt)
VALUES ('Juan Pérez', 'juan@example.com', 25, GETDATE(), GETDATE());

-- Insertar múltiples usuarios
INSERT INTO Users (Name, Email, Age, CreatedAt, UpdatedAt)
VALUES 
    ('Ana García', 'ana@example.com', 30, GETDATE(), GETDATE()),
    ('Pedro López', 'pedro@example.com', 28, GETDATE(), GETDATE()),
    ('María Sánchez', 'maria@example.com', 22, GETDATE(), GETDATE()),
    ('Carlos Rodríguez', 'carlos@example.com', 35, GETDATE(), GETDATE()),
    ('Laura Martínez', 'laura@example.com', 27, GETDATE(), GETDATE());

-- 16. Consultas con EXISTS
-- Verificar si existe un usuario con un email específico
SELECT * FROM Users u1
WHERE EXISTS (
    SELECT 1 FROM Users u2 
    WHERE u2.Email = 'test@example.com' AND u2.Id = u1.Id
);

-- Usuarios que NO tienen un email específico
SELECT * FROM Users u1
WHERE NOT EXISTS (
    SELECT 1 FROM Users u2 
    WHERE u2.Email = u1.Email AND u2.Id != u1.Id
);

-- 17. CTE (Common Table Expressions)
WITH UsuariosActivos AS (
    SELECT * FROM Users WHERE Age >= 18
)
SELECT Name, Age FROM UsuariosActivos 
WHERE Age < 65 
ORDER BY Age;

-- CTE con múltiples niveles
WITH UsuariosPorEdad AS (
    SELECT 
        *,
        CASE 
            WHEN Age < 18 THEN 'Menor'
            WHEN Age BETWEEN 18 AND 30 THEN 'Joven'
            WHEN Age BETWEEN 31 AND 50 THEN 'Adulto'
            ELSE 'Mayor'
        END AS GrupoEdad
    FROM Users
)
SELECT GrupoEdad, COUNT(*) AS Cantidad
FROM UsuariosPorEdad
GROUP BY GrupoEdad;


-- ============================================================================
-- CONSULTAS ESPECÍFICAS PARA LA TABLA USERS
-- ============================================================================

-- Usuarios más recientes
SELECT TOP 10 * FROM Users 
ORDER BY CreatedAt DESC;

-- Usuarios más antiguos
SELECT TOP 10 * FROM Users 
ORDER BY CreatedAt ASC;

-- Usuarios modificados recientemente
SELECT * FROM Users 
WHERE UpdatedAt > CreatedAt 
ORDER BY UpdatedAt DESC;

-- Usuarios nunca modificados
SELECT * FROM Users 
WHERE UpdatedAt = CreatedAt;

-- Estadísticas generales de usuarios
SELECT 
    COUNT(*) AS TotalUsuarios,
    AVG(Age) AS EdadPromedio,
    MIN(Age) AS EdadMinima,
    MAX(Age) AS EdadMaxima,
    COUNT(DISTINCT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))) AS DominiosUnicos
FROM Users;

-- Distribución de usuarios por rango de edad
SELECT 
    CASE 
        WHEN Age < 18 THEN '0-17'
        WHEN Age BETWEEN 18 AND 25 THEN '18-25'
        WHEN Age BETWEEN 26 AND 35 THEN '26-35'
        WHEN Age BETWEEN 36 AND 50 THEN '36-50'
        ELSE '50+'
    END AS RangoEdad,
    COUNT(*) AS Cantidad
FROM Users
GROUP BY 
    CASE 
        WHEN Age < 18 THEN '0-17'
        WHEN Age BETWEEN 18 AND 25 THEN '18-25'
        WHEN Age BETWEEN 26 AND 35 THEN '26-35'
        WHEN Age BETWEEN 36 AND 50 THEN '36-50'
        ELSE '50+'
    END
ORDER BY RangoEdad;

-- Dominios de email más comunes
SELECT 
    SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS Dominio,
    COUNT(*) AS Cantidad
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY Cantidad DESC;

-- Usuarios creados por mes
SELECT 
    YEAR(CreatedAt) AS Año,
    MONTH(CreatedAt) AS Mes,
    COUNT(*) AS UsuariosCreados
FROM Users
GROUP BY YEAR(CreatedAt), MONTH(CreatedAt)
ORDER BY Año DESC, Mes DESC;

-- Actividad de usuarios (diferencia entre creación y última actualización)
SELECT 
    Id,
    Name,
    Email,
    CreatedAt,
    UpdatedAt,
    DATEDIFF(DAY, CreatedAt, UpdatedAt) AS DiasDeActividad
FROM Users
ORDER BY DiasDeActividad DESC;


-- ============================================================================
-- CONSULTAS DE UTILIDAD
-- ============================================================================

-- Verificar si existe un email antes de insertar
IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'nuevo@example.com')
BEGIN
    INSERT INTO Users (Name, Email, Age, CreatedAt, UpdatedAt)
    VALUES ('Nuevo Usuario', 'nuevo@example.com', 25, GETDATE(), GETDATE());
    PRINT 'Usuario insertado correctamente';
END
ELSE
BEGIN
    PRINT 'El email ya existe';
END

-- Contar usuarios por edad específica
SELECT Age, COUNT(*) AS Cantidad 
FROM Users 
GROUP BY Age 
ORDER BY Cantidad DESC;

-- Top 5 edades más comunes
SELECT TOP 5 Age, COUNT(*) AS Cantidad 
FROM Users 
GROUP BY Age 
ORDER BY Cantidad DESC;

-- Buscar duplicados de email (no debería haber debido al índice único)
SELECT Email, COUNT(*) AS Duplicados 
FROM Users 
GROUP BY Email 
HAVING COUNT(*) > 1;

-- Limpiar tabla (CUIDADO: Elimina todos los datos)
-- TRUNCATE TABLE Users;

-- Reiniciar contador de identidad (CUIDADO: Solo usar si la tabla está vacía)
-- DBCC CHECKIDENT ('Users', RESEED, 0);


-- ============================================================================
-- CONSULTAS DE MANTENIMIENTO
-- ============================================================================

-- Ver estructura de la tabla
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Users';

-- Ver índices de la tabla
SELECT 
    i.name AS IndexName,
    i.type_desc AS IndexType,
    i.is_unique AS IsUnique,
    c.name AS ColumnName
FROM sys.indexes i
INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE i.object_id = OBJECT_ID('Users');

-- Ver restricciones de la tabla
SELECT 
    tc.CONSTRAINT_NAME,
    tc.CONSTRAINT_TYPE,
    kcu.COLUMN_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
    ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME
WHERE tc.TABLE_NAME = 'Users';
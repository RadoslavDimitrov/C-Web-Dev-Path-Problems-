USE SoftUni

BACKUP DATABASE SoftUni TO DISK = 'D:\morve\Softuni-backup.bak'


USE master

DROP DATABASE SoftUni



RESTORE DATABASE SoftUni FROM DISK = 'D:\morve\Softuni-backup.bak'
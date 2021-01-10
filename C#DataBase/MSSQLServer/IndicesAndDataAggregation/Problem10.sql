SELECT [FirstLetter]	
	FROM 
		(SELECT LEFT(FirstName, 1) as [FirstLetter]
			FROM WizzardDeposits
			WHERE DepositGroup = 'Troll Chest'
			GROUP BY FirstName
			) as [FLetter]
		GROUP BY [FirstLetter]
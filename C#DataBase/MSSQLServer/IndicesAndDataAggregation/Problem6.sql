SELECT DepositGroup, SUM(DepositAmount) as [TotalSum]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
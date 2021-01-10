SELECT DepositGroup,
				CASE 
					WHEN IsDepositExpired = 0 THEN '0'
					ELSE '1'
					END AS IsDepositExpired,
				AVG(DepositInterest) as [AverageInterest]	
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC



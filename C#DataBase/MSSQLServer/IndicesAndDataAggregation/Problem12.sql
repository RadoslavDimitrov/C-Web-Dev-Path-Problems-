SELECT SUM([Difference]) as SumOfDifference
	FROM
		(SELECT FirstName as [Host Wizzard],
				DepositAmount as [Host Wizzard Deposit],
				LEAD(FirstName) OVER (ORDER BY Id) as [Guest Wizzard],
				LEAD(DepositAmount) OVER (ORDER BY Id) as [Guest Wizzard Deposit],
				(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) as [Difference]
			FROM WizzardDeposits) as DiffAmountQuery
SELECT TOP(1) MAX(MagicWandSize) as [LongestMagicWand]
	FROM WizzardDeposits
	GROUP BY MagicWandSize
	ORDER BY [LongestMagicWand] DESC
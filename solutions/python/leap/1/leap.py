def leap_year(year):
    """
    Determines if a year is a leap year.

    Args:
        year (int): The year being tested.

    Returns:
        bool: The return value. True for a leap year, False otherwise.
    """
    return bool((year % 4 == 0 and year % 100 != 0) or (year % 100 == 0 and year % 400 == 0))
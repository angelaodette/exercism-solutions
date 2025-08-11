def is_armstrong_number(number):
    """
    Determines if a number is an Armstrong number. An Armstrong number is a 
    number that is the sum of the each digit raised to the total number of digits.

    Args:
        int: The number being tested.

    Returns:
        bool: The result determining if the number is an Armstrong number.
    """
    digits = [int(d) for d in str(number)]
    number_of_digits = len(digits)
    sum_of_digits = 0
    for digit in digits:
        sum_of_digits += digit ** number_of_digits        
    if sum_of_digits == number:
        return True
    else:
        return False
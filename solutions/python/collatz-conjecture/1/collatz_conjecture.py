def steps(number):
    """Calculate the number of steps that it takes to reach 1 according to the rules of the Collatz Conjecture.

    Args:
        number (int): The number being evaluated.

    Returns:
        int: The number of steps it takes to reach 1.
    """
    if number <= 0:
        raise ValueError("Only positive integers are allowed")
    steps = 0
    while not number == 1:
        if number % 2 == 0:
            number = number / 2
        else:
            number = number * 3 + 1
        steps += 1
    return steps
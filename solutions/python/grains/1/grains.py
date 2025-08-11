def square(number):
    """
    Calculates the number of grains on a given square of a chessboard.
    Each square has double the value of the previous square.

    Args:
        number (int): The square number (must be between 1 and 64).

    Returns:
        int: Number of grains on the given square.

    Raises:
        ValueError: If n is not between 1 and 64.
    """
    if not 1 <= number <= 64:
        raise ValueError("square must be between 1 and 64")
    return 2 ** (number - 1)

    
def total():
    """
    Calculates the number of grains on a chessboard,
    given that each square has double the value of the previous square.

    Returns:
        int: Number of grains on the chessboard.
    """
    squares = 64
    total_grains = 0
    for i in range(1, squares + 1):
        total_grains += square(i)
        
    return total_grains
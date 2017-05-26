import sys
#test_cases = open(sys.argv[1], 'r')
test_cases = open('data.txt', 'r')
for test in test_cases:
    if test == '':
        continue

    game_data = test.split('|')
    players = game_data[0].strip().split(' ')
    black_card = int(game_data[1])

    while len(players) > 1:
        if len(players) >= black_card:
            player_to_remove = black_card - 1
        else:
            player_to_remove = (black_card % len(players)) -1

        del players[player_to_remove]

    print(players[0])
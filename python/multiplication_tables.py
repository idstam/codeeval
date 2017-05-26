#  https://www.codeeval.com/open_challenges/23/

def main():
    for i in range(1, 13):
        line = ""
        for j in range(1, 13):
            num = str(i * j)
            if j == 1:
                line += num.rjust(2, ' ')
            else:
                line += num.rjust(4, ' ')
        print(line)
if __name__ == '__main__':
    main()
import matplotlib.pyplot as plt





def knapsack(weights, values, capacity):
    n = len(weights)
    dp = [[0 for _ in range(capacity + 1)] for _ in range(n + 1)]
    container_items = [[] for _ in range(n+1)]
    container_weights = [0 for _ in range(n+1)]
    container_index = 1

    for i in range(1, n + 1):
        for w in range(1, capacity + 1):
            if weights[i - 1] <= w:
                if values[i - 1] + dp[i - 1][w - weights[i - 1]] > dp[i - 1][w]:
                    dp[i][w] = values[i - 1] + dp[i - 1][w - weights[i - 1]]
                    container_items[container_index].append(i)
                    container_weights[container_index] += weights[i - 1]
                else:
                    dp[i][w] = dp[i - 1][w]

        if container_weights[container_index] > 0:
            container_index += 1

    plt.bar(range(1, container_index), container_weights[1:container_index])
    plt.xlabel('Container')
    plt.ylabel('Weight')
    plt.title('Container Item Weight Distribution')
    plt.show()

    return dp[n][capacity]

weights = [10, 20, 30]
values = [60, 100, 120]
capacity = 50
print(knapsack(weights, values, capacity))  # Output: 220
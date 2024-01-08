import matplotlib.pyplot as plt

def next_fit(item_weights, bin_capacity):
    bins = [bin_capacity]
    idx = 0

    for weight in item_weights:
        if weight <= bins[idx]:
            bins[idx] -= weight
        else:
            bins.append(bin_capacity - weight)
            idx += 1

    return len(bins)

item_weights = [4, 8, 1, 4, 2, 1]
bin_capacity = 10
print(next_fit(item_weights, bin_capacity))  # Output: 3

def visualize_next_fit(item_weights, bin_capacity):
    num_bins = next_fit(item_weights, bin_capacity)
    bins = [0] * num_bins
    idx = 0

    for weight in item_weights:
        if weight <= bin_capacity - bins[idx]:
            bins[idx] += weight
        else:
            idx += 1
            bins[idx] += weight

    plt.bar(range(1, num_bins + 1), bins, width=0.4)
    plt.xlabel('Bin number')
    plt.ylabel('Weight')
    plt.title('Next-Fit bin packing visualization')
    plt.show()

item_weights = [4, 8, 1, 4, 2, 1]
bin_capacity = 10
visualize_next_fit(item_weights, bin_capacity)
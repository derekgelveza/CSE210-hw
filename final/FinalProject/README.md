# Forgotten Realms - Text Adventure Game

A C# text-based adventure game where the player explores a 3x3 grid map, collects items, overcomes obstacles, and ultimately defeats the Goblin King.

---

## How to Run

```
dotnet run
```

---

## How to Play

When prompted, type the key shown in parentheses and press Enter.

| Key | Action |
|-----|--------|
| `n` `s` `e` `w` | Travel North / South / East / West |
| `g` | Get Item at current location |
| `u` | Use an item from your inventory |
| `i` | Show Inventory |
| `m` | Show Map |
| `q` | Quit |

**Win condition:** Travel to the Goblin Camp and use King Arthur's Sword to defeat the Goblin King.

---

## Map Layout

The world is a 3x3 grid of tiles. The player starts at tile 8 (Camp, bottom-right). Tiles are revealed as you visit them.

```
GoblinCamp | Mountain | Cabin
-----------+----------+------
Desert     | Grove    | Cave
-----------+----------+------
Dock       | Forest   | Camp  <- Start
```

---

## Project Structure

```
FinalProject/
├── Program.cs          # Entry point — gets the Game singleton and calls Start()
├── Game.cs             # Main game loop, action lists, win/lose detection
├── Player.cs           # Player state: location, inventory, movement, item pickup
├── GameMap.cs          # Builds the 3x3 tile grid and all items/obstacles
├── GameTile.cs         # A single tile: terrain, item, obstacle, neighbors
├── Item.cs             # Item model with static references for key items
├── Obstacle.cs         # Obstacle model — blocks item pickup until overcome with required item
├── TerrainType.cs      # Enum of terrain types with descriptions
└── Actions/
    ├── Action.cs           # Interface defining the action contract
    ├── AbstractAction.cs   # Base class implementing shared logic (key, description)
    ├── TravelNorthAction.cs
    ├── TravelSouthAction.cs
    ├── TravelEastAction.cs
    ├── TravelWestAction.cs
    ├── GetItemAction.cs
    ├── UseAction.cs
    ├── InventoryAction.cs
    ├── ShowMapAction.cs
    ├── SaveGameAction.cs
    ├── LoadGameAction.cs
    ├── QuitAction.cs
    └── InvalidAction.cs    # Catch-all fallback — always matches any input
```

---

## OOP Principles

**Abstraction** — The `Action` interface declares what every action must do (`CanDoAction`, `DoAction`, `GetActionDescription`, `ValidKey`) without specifying how. `AbstractAction` provides shared implementation and leaves the behavior abstract.

**Encapsulation** — `Player`, `GameTile`, `Obstacle`, and `GameMap` keep internal state private behind properties. Outside code interacts through methods like `GetItem()` and `Travel()` rather than modifying fields directly.

**Inheritance** — All action classes extend `AbstractAction`, inheriting `GetActionDescription()`, `GetKey()`, and `ValidKey()` for free. Only the behavior unique to each action needs to be written.

**Polymorphism** — `Game.cs` stores all actions in `List<Action>` and calls `CanDoAction` / `DoAction` without knowing the concrete type. `InvalidAction` overrides `ValidKey` to return `true`, making it the catch-all fallback.

---

## Key Design Decisions

- **Singleton Game** — `Game.GetInstance()` ensures only one game session exists at a time.
- **Non-consumable items** — The Axe and Cloak are reusable tools and are not removed from inventory after use. All other items are consumed on use.
- **Obstacle system** — Each tile can have one obstacle that blocks item pickup. Use the correct item (`obstacle.Required`) to clear it.
- **Save/Load** — The game saves the player's tile index and inventory item names to `savegame.txt` in plain text.

Project Title: Hero's Quest

Description:
"Hero's Quest" is a three-player game where a Barbarian, a Ranger, and a Mage compete to become the mightiest hero. Each character has unique abilities and actions they can perform during their turn. The game's code, originally poorly written with weak encapsulation and missed opportunities for inheritance, is refactored to enhance its structure and maintainability.

Objectives:

Encapsulation: Implement strict rules to protect the data within each character class, ensuring values such as health, energy, and other attributes are manipulated correctly.
Inheritance: Use inheritance to create a well-organized class hierarchy, reducing code redundancy and ensuring character-specific actions and attributes are appropriately managed.
Key Features:

Rest Action: Common to all characters, increases energy and health by a base value plus a random factor.
Energy and Health Potion Actions: Each character can consume potions to restore health or energy, adhering to specific rules.
Character-Specific Actions:
Barbarian: Gains rage with each attack and deals double damage when rage is maxed.
Ranger: Uses arrows to attack, with a chance to regain energy and pick up fired arrows.
Mage: Can throw fireballs and heal other players, creating temporary alliances.
Refactoring Goals:

Encapsulation Rules:
Ensure health, energy, potions, rage, and arrows have constraints and cannot be mismanaged.
Implement getter and setter methods where necessary to enforce rules.
Inheritance Hierarchy:
Create a base Character class with shared attributes and methods.
Derive Barbarian, Ranger, and Mage classes, each with their unique attributes and actions.
Code Reuse:
Utilize inheritance to share common methods among classes.
Override base class methods in derived classes to implement character-specific behavior.
Implementation Details:

Base Character Class:
Attributes: Name, MaxHealth, MaxEnergy, Health, Energy, HealthPotions, EnergyPotions.
Methods: Common actions like rest, use potions, and checks for valid actions.
Derived Classes:
Barbarian: Includes rage management and the SwingAxe method.
Ranger: Manages arrows and includes FireBow and PickUpArrows methods.
Mage: Includes methods for ThrowFireball and HealPlayer.
Expected Outcomes:

Improved Code Quality: Better encapsulation to protect data integrity.
Reduced Redundancy: Inheritance to avoid code duplication and enhance maintainability.
Functional Game: The refactored code should maintain or improve game functionality, adhering to the original game rules.
Summary:
The "Hero's Quest" game refactoring project focuses on enhancing code quality through encapsulation and inheritance. By organizing the character classes and their attributes/actions properly, the game becomes more maintainable and less error-prone, ensuring a robust and enjoyable gameplay experience.

# Task 4: Anti-Aircraft Hazards & Health System	

## Design

### AA

I'm thinking timed flak, much like the WW2 flak that had a timed fuse that had to be dialed in. Variable Bullet Speed, Fuse length, it requires tracking, minimum and maximum range, health system, ammo and reload time

### Health System

Several interfaces, IHealable, IHealth, IDamageable. IHealth will have a max variable, a function to update max health.
I'll see if I want it to be separate interfaces for the same system. Right now it doesn't really make much sense not to have it be the same interface.

### File locations

All of the following will be under ./MicahEidner/FlakDev/

The scripts that use the interfaces can be found @

- Scripts: ./scripts/ME_[ GameObject ]*.*

- Interfaces: ./interfaces/ME_*.*
- Prefabs: ./prefabs/ME_*.* 
- Flak: ./flak/ME_*.* 

A development scene can be found in the root folder called "flakscene"
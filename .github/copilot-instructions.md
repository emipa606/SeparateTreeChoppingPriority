# GitHub Copilot Instructions for the Separate Tree Chopping Priority (Continued) Mod

## Mod Overview and Purpose

The "Separate Tree Chopping Priority (Continued)" mod for RimWorld is an update of the original mod by Landon Martin. Its primary function is to separate plant cutting and tree chopping into distinct work priorities. This separation ensures that pawns with the Tree cutting job disabled will no longer cut down trees, even in grow zones or during construction preparation. This mod enhances the precision of job management in RimWorld, enabling players to have more control over their colony's workforce.

## Key Features and Systems

- **Separate Work Priorities**: Splits plant cutting and tree chopping into separate job categories, allowing for more precise management of work priorities.
- **Enhanced Control Over Jobs**: By default, tree cutting now takes higher priority, reducing the likelihood of pawns cutting down trees when it's not desired.
- **Improved Compatibility**: Built to work seamlessly with other mods, especially with consideration to job and work management mods.
- **Error Reporting and Community Support**: Includes instructions for error reporting and encourages community solutions through GitHub and Discord channels.

## Coding Patterns and Conventions

- **Namespaces and Files**: Each C# file in the mod is structured to represent a specific functionality or component of the mod (e.g., `WorkGiver_PlantsCut_NoTrees.cs` for handling plant cutting without affecting trees).
- **Consistent Naming**: Types and members are named to reflect their purpose clearly (e.g., `PotentialWorkThingsGlobal` in job-related classes).
- **Modular Structure**: Functions and patches are organized into relevant classes (e.g., all Harmony patches are in `HarmonyPatches.cs`) to maintain a clean and understandable codebase.

## XML Integration

- **WorkGiverDef and WorkTypeDef**: The XML files facilitate the definition and integration of new work types and work givers. This allows for seamless addition and modification of job behaviors and priorities within RimWorld.
- **Localization Support**: Utilizes XML for translation templates, helping in providing multilingual support and making the mod accessible to a wider audience.

## Harmony Patching

- **Harmony Integration**: The mod uses the Harmony library (as a dependency) for applying patches. This ensures compatibility and minimizes conflicts with the vanilla game and other mods.
- **Patch Structure**: Harmony patches are located in `HarmonyPatches.cs` which ensures an organized application of any necessary code modifications.
- **Prefix and Postfix**: Uses both prefix (e.g., in `PlantUtility_PawnWillingToCutPlant_Job.cs`) to intercept game behavior before it executes and adjusts it according to the mod’s requirements.

## Suggestions for Copilot

When using GitHub Copilot for developing or maintaining this mod, consider the following:

1. **Contextual Suggestions**: Utilize Copilot to generate context-aware code for additional features or refinements, ensuring they align with existing coding patterns and conventions.
2. **Documentation Comments**: Employ Copilot to help with documentation through `///` comments in C#, improving code readability and maintenance.
3. **Harmony Patch Templates**: Use Copilot to generate templates for new Harmony patches, making it easier to extend or add new functionalities compliant with the mod’s mechanics.
4. **XML Templates**: Take advantage of Copilot’s suggestions for XML structure, particularly when adding new work types or job classifications.
5. **Error Handling Best Practices**: Encourage Copilot to implement robust error handling patterns to facilitate smoother gameplay experiences and comprehensive log outputs. 

By following these instructions and leveraging GitHub Copilot effectively, developers can maintain and extend the Separate Tree Chopping Priority mod with greater efficiency while ensuring it remains a valuable addition to the RimWorld gaming community.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

